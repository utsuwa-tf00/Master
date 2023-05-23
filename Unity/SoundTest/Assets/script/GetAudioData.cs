using UnityEngine;

public class GetAudioData : MonoBehaviour
{
    public float sensitivity = 100f;
    public float loudness = 0f;
    public float frequency = 0f;
    public float[] audioData;

    void Start()
    {
        string deviceName = Microphone.devices[0];
        Microphone.Start(deviceName, true, 10, AudioSettings.outputSampleRate);
        audioData = new float[1024];
    }

    void Update()
    {
        Microphone.GetPosition(null, out int position);
        int offset = position - audioData.Length + 1;

        if (offset >= 0)
        {
            Microphone.GetRawData(audioData, offset);

            // 周波数と音量を取得
            AnalyzeAudioData();
        }
    }

    void AnalyzeAudioData()
    {
        // サンプリング周波数
        int sampleRate = AudioSettings.outputSampleRate;

        // FFTを実行するためのバッファサイズ
        int fftSize = 1024;

        // FFTを実行して周波数スペクトルを取得
        float[] spectrum = new float[fftSize];
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
        float frequency = maxIndex * sampleRate / (float)fftSize;

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
