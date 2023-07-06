using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Audio;

public class ScoreRecorder : MonoBehaviour
{
    public GetAudioData audioData; //GetAudioDataスクリプトの読み込み
    public CodesCheck codesCheck;
    public AudioMixerGroup masterMixer; //音を出力するためのミキサーの読み込み
    public AudioMixerGroup dummyMixer; //音を出力しないダミーのミキサーの読み込み

    public bool mic = false; //録音状態かそうでないかを切り替えるbool
    public float cutoffVol = 0.05f; //音の入力を開始する最低値
    public float tempo = 90;
    public float coolTime = 0.25f; //次の入力までの時間
    public int beat = 4;
    public int numberOfBars = 4; //小節数
    private int numberOfSounds = 64;
    public int volumeLeverage = 2; //音量の倍率

    // 内部の処理
    public string[] score = new string[16];
    public bool[] playCheck = new bool[16];
    private string resentNote = "";
    private int playCheckCount = 0;
    private int maxPlayNumber = 0;

    // 再生用のスコア
    public List<string> melodyScore = new List<string>();
    public List<float> volumeScore = new List<float>();
    private List<List<string>> backScore = new List<List<string>>();
    public string nowMelodyNote = "";
    public float nowMelodyVolume = 0;
    public List<string> nowBackCode = new List<string>();

    
    private string previousScale; // ひとつ前に入力された音名
    private AudioClip micAudioClip;
    private AudioSource audioSource;
    private float elapsedTime = 0f; // 時間計測開始からの経過時間

    private bool timeCount = false;
    private bool startPTU = false;
    private bool startPVU = false;
    private bool ptcBool = false;
    private float pcuTime = 1;

    private int soundsNumberCount;
    
    private bool playStart = false;
    private bool recStart = false;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetMicInput();

        coolTime = (60 / tempo) / 4;

        numberOfSounds = numberOfBars * beat * 4;
        
        playCheck = new bool[numberOfSounds];

        ResetAll();
        recStart = true;
    }

    private void Update()
    {
        DataUpdate();
    }

    //playCheckの処理----------------------------------------
    //playCheckをすべてfalseにする
    private void ResetPlayCheck()
    {
        for (int i = 0; i < playCheck.Length; i++)
        {
            playCheck[i] = false;
        }

        resentNote = "";
        playCheckCount = 0;
    }

    // Scoreの処理----------------------------------------
    private void ResetScores()
    {
        nowMelodyNote = "C4";
        nowMelodyVolume = 0;
        nowBackCode.Clear();

        melodyScore.Clear();
        volumeScore.Clear();
    }

    // RecModeの処理----------------------------------------
    private IEnumerator ProsesInRecMode()
    {
        for(int ns = 0; ns < numberOfSounds; ns++)
        {
            if(audioData.loudness * volumeLeverage < cutoffVol)
            {
                melodyScore.Add("");
                volumeScore.Add(0);
            }
            else
            {
                melodyScore.Add(FrequencyToScaleConverter.ConvertHertzToScale(audioData.frequency));

                float vol = 0;
                vol = audioData.loudness * volumeLeverage;
                if(vol < 1)volumeScore.Add(vol);
                else volumeScore.Add(1);
            }

            yield return new WaitForSecondsRealtime(coolTime);
        }
        playStart = true;
        MicOff();
    }

    // PlayModeの処理----------------------------------------
    private IEnumerator ProsesInPlayMode()
    {
        int count = 0;

        for(int ns = 0; ns < numberOfSounds; ns++)
        {

            nowMelodyNote = melodyScore[ns];
            nowMelodyVolume = volumeScore[ns];

            nowBackCode = codesCheck.backScore[(int)Mathf.Floor(ns / (beat*4))];

            if(nowBackCode.Count == 3)
            {
                nowBackCode.Add("");
                nowBackCode.Add("");
            }
            else if(nowBackCode.Count == 4)nowBackCode.Add("");

            // playCheckの更新
            if(resentNote != nowMelodyNote)
            {
                playCheck[count] = true;
                count++;

                resentNote = nowMelodyNote;
            }
            
            yield return new WaitForSecondsRealtime(coolTime);
        }
        count = 0;
        recStart = true;
        ResetAll();
        MicOn();
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

    //モードごとの処理----------------------------------------
    private void RecMode()
    {
        if(recStart && audioData.loudness > cutoffVol)
        {
            StartCoroutine(ProsesInRecMode());
            recStart = false;
        }
    }

    private void PlayMode()
    {
        if(playStart && codesCheck.backScore.Count == numberOfBars)
        {
            StartCoroutine(ProsesInPlayMode()); // データ出力などの処理
            playStart = false;
        }
    }

    private void ResetAll()
    {
        ResetPlayCheck();
        ResetScores();
    }

    //データの更新を行う----------------------------------------
    private void DataUpdate()
    {
        //マイクがオンになった時・オンになっている時(録音中)
        if (mic)
        {
            RecMode();
        }
        //マイクがオフになった時・オフになっっている時(再生中)
        else if(mic == false)
        {
            PlayMode();
        }
    }
}
