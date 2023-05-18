using UnityEngine;
using UnityEngine.UI;

public class DisplayAudioData : MonoBehaviour
{
    public Text gainText;
    public Text freqText;
    private GetAudio audioSource;

    void Start()
    {
        audioSource = GetComponent<GetAudio>();
    }

    void Update()
    {
        // ゲインと周波数をテキストとして表示
        gainText.text = "Gain: " + audioSource.gain.ToString("F2");
        freqText.text = "Frequency: " + audioSource.freq.ToString("F2") + " Hz";
    }
}
