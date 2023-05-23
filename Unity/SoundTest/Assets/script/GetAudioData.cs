using UnityEngine;

public class GetAudioData : MonoBehaviour
{
    public float sensitivity = 100f;
    public float loudness = 0f;
    public float frequency = 0f;
    public float[] audioData;

    private int sampleRate;
    private int bufferSize;
    private AudioClip microphoneClip;

    void Start()
    {
        string deviceName = Microphone.devices[0];
        sampleRate = AudioSettings.outputSampleRate;
        bufferSize = 1024;
        audioData = new float[bufferSize];

        microphoneClip = Microphone.Start(deviceName, true, 10, sampleRate);
    }

    void Update()
    {
        int position = Microphone.GetPosition(null);
        int offset = position - bufferSize + 1;

        if (offset >= 0)
        {
            microphoneClip.GetData(audioData, offset);

            // 周波数と音量を取得
            AnalyzeAudioData();
        }
    }

    void AnalyzeAudioData()
    {
        // FFTを実行して周波数スペクトルを取得
        float[] spectrum = new float[bufferSize];
        FFTWindow window = FFTWindow.BlackmanHarris;
        AudioListener.GetSpectrumData(spectrum, 0, window);

        // 最大の周波数成分を探す
        float maxAmplitude = 0f;
        int maxIndex = 0;

        for (int i = 0; i < spectrum.Length; i++)
        {
            if (spectrum[i] > maxAmplitude)
            {
                maxAmplitude = spectrum[i];
                maxIndex = i;
            }
        }

        // 最大周波数成分のインデックスから周波数を計算
        float frequency = maxIndex * sampleRate / (float)bufferSize;

        // ゲインを計算
        float amplitude = GetAveragedVolume() * sensitivity;

        // 値を更新
        this.frequency = frequency;
        loudness = amplitude;
    }

    float GetAveragedVolume()
    {
        float sum = 0f;
        int count = audioData.Length;

        for (int i = 0; i < count; i++)
        {
            sum += Mathf.Abs(audioData[i]);
        }

        return sum / count;
    }
}
