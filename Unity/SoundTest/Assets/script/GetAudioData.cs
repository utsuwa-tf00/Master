using UnityEngine;

public class GetAudioData : MonoBehaviour
{
    public float frequency;
    public float loudness;

    private bool isMicrophoneActive = true;

    private float[] prevSpectrum;
    private const int SpectrumSize = 1024;

    private AudioSource audioSource; // Added AudioSource reference

    void Start()
    {
        if (Microphone.devices.Length == 0)
        {
            Debug.LogError("Microphone not found!");
            isMicrophoneActive = false;
            return;
        }

        // Start recording from the microphone
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(null, true, 10, AudioSettings.outputSampleRate);
        audioSource.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { } // Wait until the microphone starts recording
        audioSource.Play();

        prevSpectrum = new float[SpectrumSize];

        // Mute AudioSource initially
        audioSource.mute = true;
    }

    void Update()
    {
        if (!isMicrophoneActive)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleMicrophoneInput();
        }

        AnalyzeAudioData();
    }

    void ToggleMicrophoneInput()
    {
        if (Microphone.IsRecording(null))
        {
            Microphone.End(null);
            audioSource.Stop();
        }
        else
        {
            audioSource.clip = Microphone.Start(null, true, 10, AudioSettings.outputSampleRate);
            while (!(Microphone.GetPosition(null) > 0)) { } // Wait until the microphone starts recording
            audioSource.Play();
        }
    }

    void AnalyzeAudioData()
    {
        float[] samples = new float[SpectrumSize];

        // Unmute AudioSource when microphone is active
        audioSource.mute = false;

        audioSource.GetOutputData(samples, 0); // Get audio samples from the audio source

        float sum = 0f;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i]; // Calculate the squared sum of the samples
        }

        float rmsValue = Mathf.Sqrt(sum / samples.Length); // Calculate the root mean square (RMS) value
        loudness = Mathf.Clamp01(rmsValue); // Clamp the loudness value between 0 and 1

        float dominantFrequency = 0f;
        float maxSpectrumValue = 0f;
        float[] spectrum = new float[SpectrumSize];
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris); // Get the audio spectrum data

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            float prev = prevSpectrum[i - 1];
            float current = prevSpectrum[i];
            float next = prevSpectrum[i + 1];

            if (spectrum[i] > prev && spectrum[i] > next && spectrum[i] > maxSpectrumValue)
            {
                maxSpectrumValue = spectrum[i];
                dominantFrequency = i * AudioSettings.outputSampleRate / 2f / spectrum.Length; // Calculate the dominant frequency
            }
        }

        frequency = dominantFrequency;

        prevSpectrum = spectrum;
    }
}
