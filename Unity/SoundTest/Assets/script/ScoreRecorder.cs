using UnityEngine;

public class ScoreRecorder : MonoBehaviour
{
    public GetAudioData audioData; // Reference to the GetAudioData script
    public bool mic = false; // Control variable for microphone input
    public float[] score = new float[16]; // Array to store the frequency data

    private string previousScale; // Variable to store the previous scale value

    private void Start()
    {
        mic = true; // Set mic to true by default
        ResetScore();
    }

    private void Update()
    {
        if (mic && audioData != null && audioData.enabled)
        {
            float frequency = audioData.frequency; // Get the frequency from the GetAudioData script
            string scale = FrequencyToScaleConverter.ConvertHertzToScale(frequency); // Convert frequency to scale (note name)

            if (scale != previousScale && audioData.loudness >= 0.04f)
            {
                StoreFrequencyData(frequency);
                previousScale = scale;

                if (ArrayIsFull())
                {
                    mic = false;
                }
            }
        }
        else if (!mic)
        {
            ResetScore();
            mic = true; // Reset mic to true when ready to record new data
        }
    }

    private void StoreFrequencyData(float frequency)
    {
        for (int i = 0; i < score.Length; i++)
        {
            if (score[i] == 0f)
            {
                score[i] = frequency;
                break;
            }
        }
    }

    private bool ArrayIsFull()
    {
        for (int i = 0; i < score.Length; i++)
        {
            if (score[i] == 0f)
            {
                return false;
            }
        }
        return true;
    }

    private void ResetScore()
    {
        for (int i = 0; i < score.Length; i++)
        {
            score[i] = 0f;
        }
    }
}
