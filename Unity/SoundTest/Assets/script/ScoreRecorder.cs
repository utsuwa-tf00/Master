using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ScoreRecorder : MonoBehaviour
{
    public GetAudioData audioData; //GetAudioDataスクリプトの読み込み
    public AudioMixerGroup masterMixer; //音を出力するためのミキサーの読み込み
    public AudioMixerGroup dummyMixer; //音を出力しないダミーのミキサーの読み込み
    public bool mic = false; //録音状態かそうでないかを切り替えるbool
    public float cutoffVol = 0.05f; //音の入力を開始する最低値
    public float coolTime = 0.25f; //次の入力までの時間
    public int numberOfBars = 4; //小節数
    private int numberOfSounds = 64;
    public int volumeLeverage = 2; //音量の倍率
    public string[] score = new string[16];
    public bool[] playCheck = new bool[16];
    private string resentNote = "";
    private int playCheckCount = 0;
    public float[] playTime = new float[16];
    public float[] inputVolumes = new float[16];
    private int maxPlayNumber = 0;

    public List<string> melodyScore = new List<string>();
    private List<float> volumeScore = new List<float>();
    public string nowMelodyNote = "";
    public float nowMelodyVolume = 0;

    
    private string previousScale;
    private AudioClip micAudioClip;
    private AudioSource audioSource;
    private float elapsedTime = 0f;

    private bool playCheckIsFull = false;
    private bool timeCount = false;
    private bool startPTU = false;
    private bool startPVU = false;
    private float playTimeCount;
    private float lastNotePlayTime;
    private bool ptcBool = false;
    private float pcuTime = 1;

    private int soundsNumberCount;

    private bool playStart = false;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetMicInput();

        numberOfSounds = numberOfBars * 16;

        score = new string[numberOfSounds];
        ResetScore();
        
        playCheck = new bool[numberOfSounds];
        ResetPlayCheck();

        playTime = new float[numberOfSounds];
        ResetPlayTime();

        inputVolumes =new float[numberOfSounds];
        ResetinputVolumes();

        ResetScores();
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
                startPTU = true;
                startPVU = true;
                timeCount = true;
            }
        }
    }

    //scoreが全て埋まったかどうか判別
    private bool ScoreIsFull()
    {
        for (int i = 0; i < score.Length; i++)
        {
            soundsNumberCount += (int)playTime[i];
            /*
            if (string.IsNullOrEmpty(score[i]))
            {
                return false;
            }
            */

            if(soundsNumberCount >= numberOfSounds)
            {
                lastNotePlayTime = (float)(playTime[i] - (numberOfSounds - soundsNumberCount));
                maxPlayNumber = i;
                soundsNumberCount = 0;
                return true;
            }
        }
        soundsNumberCount = 0;
        return false;
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
        if(playCheckCount >= maxPlayNumber)return true;
        
        return false;
    }

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

    //playCheckをすべてfalseにする
    private void ResetPlayCheck()
    {
        for (int i = 0; i < playCheck.Length; i++)
        {
            playCheck[i] = false;
        }

        resentNote = "";
        playCheckCount = 0;

        //playCheckが全てfalseになったらplayCheckIsFullをfalseにする
        playCheckIsFull = false;
    }
    
    //playTimeの処理----------------------------------------
    private void PlayTimeUpdate()
    {
        if (startPTU)
        {
            int playTimeLength =  playTime.Length;

            // scoreに音階が入力された時のみplayTimeを更新する
            for (int i = 0; i < playTimeLength; i++)
            {
                if (!string.IsNullOrEmpty(score[i]) && playTime[i] == 0) // 音階が入力された要素のみを処理する
                {
                    playTime[i] = Mathf.Floor(playTimeCount / coolTime);
                    playTimeCount = 0;
                }

                if(playTime[i] >= 5) playTime[i] = 4;
            }
            
            startPTU = false;
        }

        if (ptcBool) playTimeCount += Time.deltaTime;
    }


    private void ResetPlayTime()
    {
        resentNote = "";
        ptcBool = false;
        playTimeCount = 0;
        Array.Clear(playTime, 0, playTime.Length);
    }

    //inputVolumesの処理----------------------------------------
    public void InputVolumesUpdate()
    {
        if (startPVU)
        {
            int inputVolumesLength =  inputVolumes.Length;
            float vol = audioData.loudness*volumeLeverage;
            if(vol >= 1) vol = 1;

            // scoreに音階が入力された時のみinputVolumesを更新する
            for (int i = 0; i < inputVolumesLength; i++)
            {
                if (!string.IsNullOrEmpty(score[i]) && inputVolumes[i] == 0) // 音階が入力された要素のみを処理する
                {
                    inputVolumes[i] = vol;
                }
            }
            
            startPVU = false;
        }
    }

    private void ResetinputVolumes()
    {
        Array.Clear(inputVolumes, 0, inputVolumes.Length);
    }

    // Scoreの処理----------------------------------------
    private void GetScores()
    {
        for(int i = 0; i < numberOfSounds; i++)
        {
            if((int)playTime[i] == 0) break;
            

            for(int j = 0; j < (int)playTime[i]; j++)
            {
                if(melodyScore.Count > numberOfSounds || volumeScore.Count > numberOfSounds) break;
                melodyScore.Add(score[i]);
                volumeScore.Add(inputVolumes[i]);
            }
        }
    }

    private void ResetScores()
    {
        nowMelodyNote = "C4";
        nowMelodyVolume = 0;
        melodyScore.Clear();
        volumeScore.Clear();
    }

    // 現在再生されている音のデータを取得する処理----------------------------------------
    private IEnumerator PlayMode()
    {
        for(int ns = 0; ns < numberOfSounds; ns++)
        {

            nowMelodyNote = melodyScore[ns];
            nowMelodyVolume = volumeScore[ns];

            if(resentNote != nowMelodyNote)
            {
                playCheck[playCheckCount] = true;
                playCheckCount++;
            }
            resentNote = nowMelodyNote;

            yield return new WaitForSecondsRealtime(coolTime);
        }
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
        //マイクがオンになった時・オンになっている時(録音中)
        if (mic && playCheckIsFull == false)
        {
            //scoreがいっぱいになったらmicをfalseにする
            if (ScoreIsFull())
            {
                GetScores();
                playStart = true;
                MicOff();
            }
            else
            {
                ScoreUpdate();
                PlayTimeUpdate();
                InputVolumesUpdate();
            }
        }
        //マイクがオフになった時・オフになっっている時(再生中)
        else if(mic == false)
        {
            if(playStart)
            {
                StartCoroutine(PlayMode());
                playStart = false;
            }

            //playCheckが全てtrueになったら実行
            //データのリセット
            if(PlayCheckIsFull())
            {
                timeCount = true;
                playCheckIsFull = true;
                WaitForCoolTime(lastNotePlayTime);
            }
            else
            {
                //再生を行う(再生された音にチェック)
                //PlayCheckUpdate();
            }

            if(playCheckIsFull && !timeCount)
            {
                ResetScore();
                ResetPlayTime();
                ResetinputVolumes();
                ResetPlayCheck();
                lastNotePlayTime = 0;
                ResetScores();
                MicOn();
            }
        }
    }
}
