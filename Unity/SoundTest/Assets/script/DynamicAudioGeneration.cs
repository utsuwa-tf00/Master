using UnityEngine;

public class DynamicAudioGeneration : MonoBehaviour
{
    public ScoreRecorder scoreRecorder;
    public float gain = 0.1f; // ゲイン（音量）の設定
    public float sampleRate = 48000f; // サンプルレート
    public float noteChangeInterval = 1f; // 音の切り替え間隔

    private float phase; // sin波の位相

    private float increment;
    private float time;
    private bool isPlaying = false;

    private float frequency;

    private int currentScoreIndex = 0;
    private float noteChangeTimer = 0f;

    void Update()
    {
        if (isPlaying)
        {
            if (currentScoreIndex >= scoreRecorder.score.Length)
            {
                StopPlaying();
            }
            else
            {
                noteChangeTimer += Time.deltaTime;
                if (noteChangeTimer >= noteChangeInterval)
                {
                    noteChangeTimer = 0f;
                    string noteName = scoreRecorder.score[currentScoreIndex];
                    frequency = FrequencyLibrary.frequencyLibrary[noteName];
                    currentScoreIndex++;
                }
            }
        }
        else if (!scoreRecorder.mic)
        {
            StartPlaying();
        }
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        if (!isPlaying)
        {
            return;
        }

        increment = frequency * 2 * Mathf.PI / sampleRate;

        for (var i = 0; i < data.Length; i = i + channels)
        {
            time = time + increment;
            if (time > -Mathf.PI && time <= 0) data[i] = -1;
            if (time > 0 && time <= Mathf.PI) data[i] = 1;
            if (channels == 2) data[i + 1] = data[i];
            if (time > 2 * Mathf.PI) time = 0;
        }
    }

    public void StartPlaying()
    {
        isPlaying = true;
        currentScoreIndex = 0;
        noteChangeTimer = 0f;
    }

    public void StopPlaying()
    {
        isPlaying = false;
        scoreRecorder.mic = true;
    }
}
