using UnityEngine;
using System;  // Add using statement for System

public class GetAudioData : MonoBehaviour
{
    public float sensitivity = 100f;
    public float loudness = 0f;
    public float frequency = 0f;
    public float[] audioData;

    public int SampleRate { get { return sampleRate; } }  // Add SampleRate property

    public int sampleRate;
    private int bufferSize;
    private AudioClip microphoneClip;

    void Start()
    {
        string deviceName = Microphone.devices[0];
        bufferSize = 8192;
        audioData = new float[bufferSize];

        microphoneClip = Microphone.Start(deviceName, true, 10, 44100);

        sampleRate = 44100;  // デフォルトのサンプルレートを使用
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
        // スペクトルデータを複製
        float[] spectrumCopy = new float[bufferSize];
        Array.Copy(audioData, spectrumCopy, bufferSize);

        // FFTアルゴリズムを適用
        ApplyFFT(spectrumCopy);

        // 最大の周波数成分を探す
        float maxAmplitude = 0f;
        int maxIndex = 0;

        // 配列の一部分から最大の周波数成分を見つける
        int startIndex = 0;  // スペクトルデータの開始インデックス
        int endIndex = spectrumCopy.Length;  // スペクトルデータの終了インデックス
        for (int i = startIndex; i < endIndex; i++)
        {
            if (spectrumCopy[i] > maxAmplitude)
            {
                maxAmplitude = spectrumCopy[i];
                maxIndex = i;
            }
        }

        // 最大周波数成分のインデックスから周波数を計算
        float binWidth = SampleRate / (float)bufferSize;  // バンド幅
        frequency = maxIndex * binWidth;

        // ゲインを計算
        float amplitude = GetAveragedVolume() * sensitivity;

        // 値を更新
        loudness = amplitude;
    }

    void ApplyFFT(float[] spectrum)
    {
        // 入力配列の長さを取得
        int N = spectrum.Length;

        // 入力配列の長さが2のべき乗でない場合は、ゼロパディングする
        if (!IsPowerOfTwo(N))
        {
            int nextPowerOfTwo = Mathf.NextPowerOfTwo(N);
            Array.Resize(ref spectrum, nextPowerOfTwo);
            N = nextPowerOfTwo;
        }

        // FFTを計算する
        FFTRecursive(spectrum, 0, N, 1);
    }

    bool IsPowerOfTwo(int number)
    {
        return (number & (number - 1)) == 0;
    }

    void FFTRecursive(float[] spectrum, int startIndex, int length, int stride)
    {
        if (length < 2)  // 配列の長さが2未満の場合に修正
        {
            return;
        }

        // 入力配列を偶数部分と奇数部分に分割する
        int evenLength = length / 2;
        float[] even = new float[evenLength];
        float[] odd = new float[evenLength];
        for (int i = 0; i < evenLength; i++)
        {
            even[i] = spectrum[startIndex + i * 2];
            odd[i] = spectrum[startIndex + i * 2 + 1];
        }

        // 偶数部分と奇数部分に再帰的にFFTを適用する
        FFTRecursive(even, 0, evenLength, stride * 2);
        FFTRecursive(odd, 0, evenLength, stride * 2);

        // FFTの結果を計算する
        for (int k = 0; k < evenLength; k++)
        {
            // Twiddle factor（回転因子）を計算
            float angle = -2 * Mathf.PI * k / length;
            float cosine = Mathf.Cos(angle);
            float sine = Mathf.Sin(angle);

            // 偶数部分と奇数部分の組み合わせでDFTを計算
            float evenValue = even[k];
            float oddValue = odd[k];
            float twiddleReal = cosine * oddValue - sine * evenValue;
            float twiddleImaginary = cosine * evenValue + sine * oddValue;

            // 結果を格納
            spectrum[startIndex + k] = evenValue + twiddleReal;
            spectrum[startIndex + k + evenLength] = oddValue - twiddleImaginary;
        }
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
