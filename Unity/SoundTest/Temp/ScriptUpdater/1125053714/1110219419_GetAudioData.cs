using UnityEngine;

public class GetAudioData : MonoBehaviour
{
    public float frequency;
    public float loudness;

    private bool isRecording = false;

    void Start()
    {
        // マイクのデバイス名をログに表示
        string[] devices = Microphone.devices;
        foreach (string device in devices)
        {
            Debug.Log("Microphone: " + device);
        }

        // マイク入力の開始
        StartMicrophoneInput();
    }

    void Update()
    {
        // スペースキーでマイク入力の停止と再開
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isRecording)
            {
                StopMicrophoneInput();
            }
            else
            {
                StartMicrophoneInput();
            }
        }

        // 周波数と音量の更新
        UpdateAudioData();
    }

    void OnDestroy()
    {
        // マイク入力の停止
        StopMicrophoneInput();
    }

    void StartMicrophoneInput()
    {
        // マイク入力の開始
        GetComponent<AudioSource>().clip = Microphone.Start(null, true, 1, AudioSettings.outputSampleRate);
        GetComponent<AudioSource>().loop = true;
        isRecording = true;
    }

    void StopMicrophoneInput()
    {
        // マイク入力の停止
        Microphone.End(null);
        isRecording = false;
    }

    void UpdateAudioData()
    {
        if (isRecording)
        {
            // オーディオデータの取得
            float[] audioData = new float[1024];
            GetComponent<AudioSource>().GetOutputData(audioData, 0);

            // 音声処理
            AnalyzeSound(audioData, GetComponent<AudioSource>().clip.frequency);

            // 周波数と音量の更新
            frequency = pitchValue;
            loudness = audioData.Average(); // 平均値を音量として使用（仮の値）

            Debug.Log("Frequency: " + frequency);
            Debug.Log("Loudness: " + loudness);
        }
    }

    void AnalyzeSound()
    {
        GetComponent<AudioSource>().GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        float maxV = 0;
        int maxN = 0;
        //最大値（ピッチ）を見つける。ただし、閾値は超えている必要がある
        for (int i = 0; i < qSamples; i++)
        {
            if (spectrum[i] > maxV && spectrum[i] > threshold)
            {
                maxV = spectrum[i];
                maxN = i;
            }
        }

        float freqN = maxN;
        if (maxN > 0 && maxN < qSamples - 1)
        {
            //隣のスペクトルも考慮する
            float dL = spectrum[maxN - 1] / spectrum[maxN];
            float dR = spectrum[maxN + 1] / spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        pitchValue = freqN * (fSample / 2) / qSamples;
    }

}
