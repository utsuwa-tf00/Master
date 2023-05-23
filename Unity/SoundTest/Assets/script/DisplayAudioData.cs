using UnityEngine;
using UnityEngine.UI;

public class DisplayAudioData : MonoBehaviour
{
    public Text loudness;
    public Text freqText;
    public Text noteText;
    private GetAudioData audioSource; // GetAudioDataに変更

    void Start()
    {
        audioSource = GetComponent<GetAudioData>();
    }

    void Update()
    {
        // ゲインと周波数をテキストとして表示
        loudness.text = "Loudness: " + audioSource.loudness.ToString("F2");
        freqText.text = "Frequency: " + audioSource.frequency.ToString("F2") + " Hz";
    }
}
