using UnityEngine;
using UnityEngine.Audio;

public class GetAudioData : MonoBehaviour
{
    public float frequency = 0f;
    public float loudness = 0f;

    private bool isMicrophoneActive = true;

    private float[] prevSpectrum;
    public const int SpectrumSize = 2048;

    private AudioSource audioSource;
    public AudioMixerGroup dummyMixer;

    void Start()
    {
        frequency = 0f;
        loudness = 0f;

        if (Microphone.devices.Length == 0)
        {
            Debug.LogError("Microphone not found!");
            isMicrophoneActive = false;
            return;
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(null, true, 10, AudioSettings.outputSampleRate);
        audioSource.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        audioSource.Play();

        prevSpectrum = new float[SpectrumSize];

        audioSource.outputAudioMixerGroup = dummyMixer;
    }

    void Update()
    {
        if (!isMicrophoneActive)
            return;

        AnalyzeAudioData();
    }

    void AnalyzeAudioData()
    {
        float[] samples = new float[SpectrumSize];

        audioSource.GetOutputData(samples, 0);

        float sum = 0f;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i];
        }

        float rmsValue = Mathf.Sqrt(sum / samples.Length);
        loudness = Mathf.Clamp01(rmsValue);

        float dominantFrequency = 0f;
        float maxSpectrumValue = 0f;
        float[] spectrum = new float[SpectrumSize];
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            float prev = prevSpectrum[i - 1];
            float current = prevSpectrum[i];
            float next = prevSpectrum[i + 1];

            if (spectrum[i] > prev && spectrum[i] > next && spectrum[i] > maxSpectrumValue)
            {
                maxSpectrumValue = spectrum[i];
                dominantFrequency = i * AudioSettings.outputSampleRate / 2f / spectrum.Length;
            }
        }

        frequency = Microphone.IsRecording(null) ? dominantFrequency : 0f;

        prevSpectrum = spectrum;
    }
}
