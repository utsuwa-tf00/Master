using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundPlayer : MonoBehaviour
{
    public ScoreRecorder scoreRecorder;
    public float gain = 0.1f; // ゲイン（音量）の設定
    public float sampleRate = 48000f; // サンプルレート
    [SerializeField, Range(1,4)]
    public int PlayState = 1;

    public int backgroundNumber;

    private float increment;
    private float time;
    private bool isPlaying = false;

    private float frequency;
    private float preFrequency;

    public float volume;
    public float preVolume;


    void Start()
    {

    }
    
    void Update()
    {
        if(scoreRecorder.isPlaying)
        {
            isPlaying = true;
            if(scoreRecorder.nowBackCode.Count == 5)
            {
                if(NoteNameIdentification.Back(scoreRecorder.nowBackCode[backgroundNumber]) != "")
                {
                    frequency = FrequencyLibrary.frequencyLibrary[NoteNameIdentification.Back(scoreRecorder.nowBackCode[backgroundNumber])];
                    preFrequency = frequency;
                    preVolume = 0.05f;
                }
                else
                {
                    frequency = preFrequency;
                    preVolume = 0;
                }
            }
        }

        volume = Mathf.Lerp(volume, preVolume, 0.01f);
    }

    void SineWave(float[] data, int channels)
    {
        increment = frequency * 4 * Mathf.PI / sampleRate;
        for (var i = 0; i < data.Length; i = i + channels)
        {
            time = time + increment;
            data[i] = Mathf.Sin(time) * volume;
            if (channels == 2) data[i + 1] = data[i];
            if (time > 2 * Mathf.PI) time = 0;
        }
    }

    void SquareWave(float[] data, int channels)
    {
        increment = frequency * 4 * Mathf.PI / sampleRate;
        for (var i = 0; i < data.Length; i = i + channels)
        {
            time = time + increment;
            if (time > -Mathf.PI && time <= 0) data[i] = -1 * volume;
            if (time > 0 && time <= Mathf.PI) data[i] = 1 * volume;
            if (channels == 2) data[i + 1] = data[i];
            if (time > 2 * Mathf.PI) time = 0;
        }
    }

    void TriangleWave(float[] data, int channels)
    {
        increment = frequency * 4 * Mathf.PI / sampleRate;
        for (var i = 0; i < data.Length; i = i + channels)
        {
            time = time + increment;
            if (time > -Mathf.PI && time <= -Mathf.PI / 2) data[i] = (-2 * (time + Mathf.PI)) * volume;
            if (time > -Mathf.PI / 2 && time <= Mathf.PI / 2) data[i] = (2 * time * volume);
            if (time > Mathf.PI / 2 && time <= Mathf.PI) data[i] = (-2 * (time - Mathf.PI) * volume);
            if (channels == 2) data[i + 1] = data[i];
            if (time > 2 * Mathf.PI) time = 0;
        }
    }

    void SawtoothWave(float[] data, int channels)
    {
        increment = frequency * 4 * Mathf.PI / sampleRate;
        for (var i = 0; i < data.Length; i = i + channels)
        {
            time = time + increment;
            data[i] = (float)(0.5 * ((time + Mathf.PI) % (Mathf.PI * 2)) / Mathf.PI - 1.0) * volume;
            if (channels == 2) data[i + 1] = data[i];
            if (time > 2 * Mathf.PI) time = 0;
        }
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        if (!isPlaying)
        {
            return;
        }

        switch (PlayState)
        {
            case 1:
                SineWave(data, channels);
                break;
            case 2:
                SquareWave(data, channels);
                break;
            case 3:
                TriangleWave(data, channels);
                break;
            case 4:
                SawtoothWave(data, channels);
                break;
        }
    }
}
