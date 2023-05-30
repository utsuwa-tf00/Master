using UnityEngine;

public class FrequencyToScaleConverter : MonoBehaviour
{
    public string scale; // Converted scale value (note name)
    public string noteName; // Note name
    public int octave; // Octave

    private static string[] noteNames = { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#" };
    private GetAudioData audioData; // Reference to the GetAudioData script

    void Start()
    {
        audioData = GetComponent<GetAudioData>(); // Get the GetAudioData script from the same GameObject
    }

    void Update()
    {
        float frequency = audioData.frequency; // Get the frequency from the GetAudioData script

        scale = ConvertHertzToScale(frequency); // Convert frequency to scale (note name)
        noteName = GetNoteName(scale); // Get note name from scale
        octave = GetOctave(scale); // Get octave from scale

        // Debug.Log("Frequency: " + frequency.ToString("F2") + " Hz, Scale: " + scale);
    }

    public static string ConvertHertzToScale(float hertz)
    {
        if (hertz == 0) return string.Empty;

        float scaleValue = 12.0f * Mathf.Log(hertz / 110.0f) / Mathf.Log(2.0f);
        int scaleIndex = Mathf.FloorToInt(scaleValue) % noteNames.Length;

        if (scaleIndex < 0)
            scaleIndex += noteNames.Length;

        string noteName = noteNames[scaleIndex];

        int octave = Mathf.FloorToInt(scaleValue / 12.0f) + 1;

        return noteName + octave.ToString();
    }

    private string GetNoteName(string scale)
    {
        if (scale.Length <= 1)
            return string.Empty;

        return scale.Substring(0, scale.Length - 1);
    }

    private int GetOctave(string scale)
    {
        if (scale.Length <= 0)
            return 0;

        int.TryParse(scale[scale.Length - 1].ToString(), out int octave);
        return octave;
    }
}
