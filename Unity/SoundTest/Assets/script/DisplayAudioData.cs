using UnityEngine;
using UnityEngine.UI;

public class DisplayAudioData : MonoBehaviour
{
    public Text loudness;
    public Text freqText;
    public Text noteText; // 追加: 音階名を表示するテキスト
    private GetAudio audioSource;
    private AnalyzePitch pitchAnalyzer; // 追加: AnalyzePitchコンポーネント

    void Start()
    {
        audioSource = GetComponent<GetAudio>();
        pitchAnalyzer = GetComponent<AnalyzePitch>(); // 追加: AnalyzePitchコンポーネントを取得
    }

    void Update()
    {
        // ゲインと周波数をテキストとして表示
        loudness.text = "Loudness: " + audioSource.loudness.ToString("F2");
        freqText.text = "Frequency: " + audioSource.freq.ToString("F2") + " Hz";

        // 音階名をテキストとして表示
        noteText.text = "Note: " + pitchAnalyzer.currentNote;
    }
}
