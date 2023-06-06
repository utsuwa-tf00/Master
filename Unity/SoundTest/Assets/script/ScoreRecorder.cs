using UnityEngine;

public class ScoreRecorder : MonoBehaviour
{
    public GetAudioData audioData; // Reference to the GetAudioData script
    public bool mic = false; // Control variable for microphone input
    public float cutoffVol = 0.05f;
    public float coolTime = 0.25f; // Minimum time interval between note assignments
    public string[] score = new string[16]; // Array to store the note names
    
    private string previousScale; // Variable to store the previous scale value
    private AudioClip micAudioClip; // Reference to the microphone audio clip
    private AudioSource audioSource; // Reference to the AudioSource component
    private bool dataUpdate = false;
    private float elapsedTime = 0f; // Elapsed time since the last note assignment

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetMicInput();
    }

    private void Update()
    {
        DataUpdate();

        if (mic && audioData != null && audioData.enabled)
        {
            float frequency = audioData.frequency; // Get the frequency from the GetAudioData script
            string scale = FrequencyToScaleConverter.ConvertHertzToScale(frequency); // Convert frequency to scale (note name)

            if (scale != previousScale && audioData.loudness >= cutoffVol && elapsedTime >= coolTime)
            {
                StoreNoteName(scale);
                previousScale = scale;
                elapsedTime = 0f;

                if (ArrayIsFull())
                {
                    mic = false;
                    DetachMic();
                }
            }
        }

        elapsedTime += Time.deltaTime;
    }

    private void SetMicInput()
    {
        micAudioClip = Microphone.Start(null, true, 1, AudioSettings.outputSampleRate);
        audioSource.clip = micAudioClip;
        audioSource.Play();
    }

    private void DetachMic()
    {
        audioSource.clip = null;
        dataUpdate = true;
    }

    private void StoreNoteName(string scale)
    {
        for (int i = 0; i < score.Length; i++)
        {
            if (string.IsNullOrEmpty(score[i]))
            {
                score[i] = scale;
                break;
            }
        }
    }

    private bool ArrayIsFull()
    {
        for (int i = 0; i < score.Length; i++)
        {
            if (string.IsNullOrEmpty(score[i]))
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
            score[i] = string.Empty;
        }
    }

    private void DataUpdate()
    {
        if (mic)
        {
            if (dataUpdate)
            {
                ResetScore();
                SetMicInput();
                dataUpdate = false;
            }
        }
        else
        {
            DetachMic();
        }
    }
}
