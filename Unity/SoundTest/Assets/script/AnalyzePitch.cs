using UnityEngine;

public class AnalyzePitch : MonoBehaviour
{
    private GetAudio audioSource;
    public string currentNote = "";

    void Start()
    {
        audioSource = GetComponent<GetAudio>();
    }

    void Update()
    {
        // 音階を分析して文字列として格納
        currentNote = AnalyzePitchToNote();
    }

    string AnalyzePitchToNote()
    {
        // 参考: 12平均律の音階の周波数比率
        float[] frequencyRatios = {
            1.0f, 1.05946f, 1.12246f, 1.18921f, 1.25992f, 1.33483f,
            1.41421f, 1.49831f, 1.58740f, 1.68179f, 1.78180f, 1.88775f
        };

        // 基準となるA4音の周波数 (440Hz)
        float referenceFrequency = 440f;

        // ピッチから最も近い音階の周波数を探す
        float targetFrequency = audioSource.freq;
        float minDifference = float.MaxValue;
        int closestIndex = -1;

        for (int i = 0; i < frequencyRatios.Length; i++)
        {
            float frequency = referenceFrequency * frequencyRatios[i];
            float difference = Mathf.Abs(targetFrequency - frequency);

            if (difference < minDifference)
            {
                minDifference = difference;
                closestIndex = i;
            }
            else
            {
                // 周波数の差が増えた場合、それ以上の音階はチェック不要と判断してループを終了
                break;
            }
        }

        // 最も近い音階の文字列を返す
        string[] noteNames = {
            "A", "A#", "B", "C", "C#", "D",
            "D#", "E", "F", "F#", "G", "G#"
        };

        if (closestIndex != -1)
        {
            return noteNames[closestIndex];
        }

        return "";
    }
}
