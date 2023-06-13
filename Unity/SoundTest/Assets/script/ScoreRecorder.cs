using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class ScoreRecorder : MonoBehaviour
{
    public GetAudioData audioData; // Reference to the GetAudioData script
    public bool mic = false; // Control variable for microphone input
    public float cutoffVol = 0.05f;
    public float coolTime = 0.25f; // Minimum time interval between note assignments
    public string[] score = new string[16]; // Array to store the note names
    public bool[] playCheck = new bool[16];
    public float[] playTime = new float[16];

    public AudioMixerGroup masterMixer; // Reference to the master AudioMixer
    public AudioMixerGroup dummyMixer; // Reference to the dummy AudioMixer
    
    private string previousScale; // Variable to store the previous scale value
    private AudioClip micAudioClip; // Reference to the microphone audio clip
    private AudioSource audioSource; // Reference to the AudioSource component
    private bool dataUpdate = false;
    private float elapsedTime = 0f; // Elapsed time since the last note assignment

    private bool playCheckIsFull = false;
    private bool timeCount = false;
    private bool inputScore = false;
    public float playTimeCount;
    private bool ptcBool = false;
    private float pcuTime = 1;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetMicInput();
        
        playCheck = new bool[score.Length]; // playCheckの長さをscoreと同じにする
        ResetPlayCheck(); // playCheckを初期化

        playTime = new float[score.Length]; // playTimeの長さをscoreと同じにする
        playTime[0] = 0; // playTimeの最初の要素を0に設定
    }

    private void Update()
    {
        DataUpdate();
    }

    //coolTime秒まつ処理----------------------------------------
    private void WaitForCoolTime(float time)
    {
        if(timeCount)
        {
            if(elapsedTime >= coolTime * time)
            {
                elapsedTime = 0f;
                timeCount = false;
            }

            elapsedTime += Time.deltaTime;
        }
    }

    //マイクの設定----------------------------------------
    private void SetMicInput()
    {
        micAudioClip = Microphone.Start(null, true, 1, AudioSettings.outputSampleRate);
        audioSource.clip = micAudioClip;
        audioSource.outputAudioMixerGroup = dummyMixer; // Set the output to the dummy AudioMixer
        audioSource.Play();
    }

    private void DetachMic()
    {
        audioSource.clip = null;
        audioSource.outputAudioMixerGroup = masterMixer; // Set the output to the master AudioMixer
    }

    //scoreの処理----------------------------------------
    //scoreに音階の入力
    private void StoreNoteName(string scale)
    {
        for (int i = 0; i < score.Length; i++)
        {
            if (string.IsNullOrEmpty(score[i]))
            {
                if(scale == "C8")break;
                score[i] = scale;
                ptcBool = true;
                break;
            }
        }
    }
    
    private void ScoreUpdate()
    {
        WaitForCoolTime(1);

        if (audioData != null && audioData.enabled)
        {
            float frequency = audioData.frequency; // Get the frequency from the GetAudioData script
            string scale = FrequencyToScaleConverter.ConvertHertzToScale(frequency); // Convert frequency to scale (note name)

            if (scale != previousScale && audioData.loudness >= cutoffVol && timeCount == false)
            {
                StoreNoteName(scale);
                previousScale = scale;
                inputScore = true;
                timeCount = true;
            }
        }
    }

    //scoreが全て埋まったかどうか判別
    private bool ScoreIsFull()
    {
        for (int i = 0; i < score.Length; i++)
        {
            if (string.IsNullOrEmpty(score[i]))
            {
                return false;
            }
        }
        return true;
    }

    //scoreを全て空にする
    private void ResetScore()
    {
        for (int i = 0; i < score.Length; i++)
        {
            score[i] = string.Empty;
        }
    }

    //playCheckの処理----------------------------------------
    //playCheckが全て埋まったかどうか判別
    private bool PlayCheckIsFull()
    {
        for (int i = 0; i < playCheck.Length; i++)
        {
            if (!playCheck[i])
            {
                return false;
            }
        }

        return true;
    }

    //playCheckをすべてfalseにする
    private void ResetPlayCheck()
    {
        for (int i = 0; i < playCheck.Length; i++)
        {
            playCheck[i] = false;
        }

        //playCheckが全てfalseになったらplayCheckIsFullをfalseにする
        playCheckIsFull = false;
    }

    private void StorePlayCheck(bool pc)
    {
        bool store = true;

        for (int i = 0; i < score.Length; i++)
        {
            if (store && playCheck[i] == false)
            {
                playCheck[i] = pc;
                store = false;
                break;
            }
        }
    }

    //playCheckの処理----------------------------------------
    //playCheckを更新
    private void PlayCheckUpdate()
    {
        bool store = true;
        
        if(timeCount == false)
        {
            for (int i = 0; i < playCheck.Length; i++)
            {
                if (!playCheck[i] && store)
                {
                    pcuTime = playTime[i];
                    StorePlayCheck(true);
                    elapsedTime = 0f;
                    store = false;
                    timeCount = true;
                }
            }
        }

        WaitForCoolTime(pcuTime);
    }

    private void PlayTimeUpdate()
    {
        if (inputScore)
        {
            // scoreに音階が入力された時のみplayTimeを更新する
            for (int i = 0; i < playTime.Length; i++)
            {
                if (!string.IsNullOrEmpty(score[i]) && playTime[i] == 0 && i != 0) // 音階が入力された要素のみを処理する
                {
                    playTime[i] = Mathf.Floor(playTimeCount / coolTime);
                    playTimeCount = 0;
                }
            }
            inputScore = false;
        }

        if (ptcBool) playTimeCount += Time.deltaTime;
    }


    private void ResetPlayTime()
    {
        ptcBool = false;
        playTimeCount = 0;
        Array.Clear(playTime, 0, playTime.Length);
    }


    //dataUpdate内のマイクの処理----------------------------------------
    private void MicOn()
    {
        SetMicInput();
        mic = true;
    }

    private void MicOff()
    {
        DetachMic();
        mic = false;
    }

    //データの更新を行う----------------------------------------
    private void DataUpdate()
    {
        //マイクがオンになった時・オンになっている時
        if (mic && playCheckIsFull == false)
        {
            //scoreがいっぱいになったらmicをfalseにする
            if (ScoreIsFull())
            {
                MicOff();
            }
            else
            {
                ScoreUpdate();
                PlayTimeUpdate();
            }
        }
        //マイクがオフになった時・オフになっっている時
        else if(mic == false)
        {
            //playCheckが全てtrueになったら実行
            //データのリセット
            if(PlayCheckIsFull())
            {
                playCheckIsFull = true;
                timeCount = true;
            }
            else
            {
                //再生を行う(再生された音にチェック)
                PlayCheckUpdate();
            }

            if(playCheckIsFull)
            {
                ResetScore();
                ResetPlayTime();
                ResetPlayCheck();
                MicOn();
            }
        }
    }
}
