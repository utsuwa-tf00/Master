using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class GetAudio : MonoBehaviour
{
    [Range(0.001f, 100f)]
    public float sensitivity = 100f;
    public float loudness = 0;
    public float freq = 0;
    public float gain = 0;
    AudioSource _audio;

    public delegate void OnAudioCaptured(float[] samples);
    public static event OnAudioCaptured AudioCaptured;

    private float[] audioData;
    private static float[] _audioSamples;

    public static float[] audioSamples
    {
        get { return _audioSamples; }
        set { _audioSamples = value; }
    }

    // 追加: サンプル数を指定する変数
    [Range(128, 8192)]
    public int sampleCount = 1024;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.clip = Microphone.Start(null, true, 10, 44100);
        _audio.loop = true;
        _audio.mute = false;
        while (!(Microphone.GetPosition(null) > 0)) { }
        _audio.Play();

        // サンプル数を指定してオーディオデータ配列を初期化
        audioData = new float[sampleCount];

        if (_audio.clip == null)
        {
            Debug.LogError("Microphone.Start() failed");
        }
    }

    void Update()
    {
        _audio.GetOutputData(audioData, 0);

        loudness = GetAveragedVolume() * sensitivity;
        freq = GetFundamentalFrequency();
        gain = GetMaxVolume();

        AudioCaptured?.Invoke(audioData);

        audioSamples = audioData;
    }

    float GetAveragedVolume()
    {
        float a = 0;
        foreach (float s in audioData)
        {
            a += Mathf.Abs(s);
        }
        return a / audioData.Length;
    }

    float GetMaxVolume()
    {
        float maxVolume = 0f;
        for (int i = 0; i < audioData.Length; i++)
        {
            if (Mathf.Abs(audioData[i]) > maxVolume)
            {
                maxVolume = Mathf.Abs(audioData[i]);
            }
        }
        return maxVolume;
    }

    float GetFundamentalFrequency()
    {
        float[] spectrumData = new float[8192];
        _audio.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);
        float maxAmplitude = 0f;
        int maxIndex = 0;
        for (int i = 1; i < spectrumData.Length; i++)
        {
            if (spectrumData[i] > maxAmplitude)
            {
                maxAmplitude = spectrumData[i];
                maxIndex = i;
            }
        }
        float fundamentalFrequency = 44100f * maxIndex / 8192f;
        return fundamentalFrequency;
    }
}
