using UnityEngine;

public class DynamicAudioGeneration : MonoBehaviour
{
    public GetAudioData audioData;
    public float frequencyMultiplier = 1; // 周波数の倍率
    public float gain = 0.1f; // ゲイン（音量）の設定
    public float sampleRate = 44100f; // サンプルレート

    private float phase; // sin波の位相

    private float increment;
    private float time;


    void OnAudioFilterRead(float[] data, int channels)
    {
        if (audioData == null)
        {
            Debug.LogError("GetAudioData reference is missing!");
            return;
        }

        float frequency = audioData.frequency;
        increment = frequency * 4 * Mathf.PI / sampleRate;
        for (var i = 0; i < data.Length; i = i + channels)
        {
            time = time + increment;
            data[i] = Mathf.Sin(time);
            if (channels == 2) data[i + 1] = data[i];
            if (time > 2 * Mathf.PI) time = 0;
        }
        
        /*
        for (int i = 0; i < data.Length; i += channels)
        {
            // 周波数データから周波数を計算
            float frequency = audioData.frequency * frequencyMultiplier;

            // sin波の生成
            float sample = Mathf.Sin(2f * Mathf.PI * frequency * phase);

            // ゲインを適用して音量調整
            //sample *= gain;
            sample *= audioData.loudness;

            // 各チャンネルにサンプルを書き込む
            for (int j = 0; j < channels; j++)
            {
                data[i + j] = sample;
            }

            // 位相を更新
            phase += 1f / sampleRate;

            // 位相が1.0を超えたらループさせる
            if (phase > 1f)
            {
                phase -= 1f;
            }
        }
        */
    }
}
