using UnityEngine;

public class FrequencyToScaleConverter : MonoBehaviour
{
    public string scale; // Converted scale value (note name)

    private GetAudioData audioData; // Reference to the GetAudioData script

    void Start()
    {
        audioData = GetComponent<GetAudioData>(); // Get the GetAudioData script from the same GameObject
    }

    void Update()
    {
        float frequency = audioData.frequency; // Get the frequency from the GetAudioData script

        scale = ConvertHertzToScale(frequency); // Convert frequency to scale (note name)
    }

    public static string ConvertHertzToScale(float hertz)
    {
        if (hertz == 0) return string.Empty;

        string closestNote = string.Empty;
        float closestDistance = float.MaxValue;

        foreach (var noteFrequency in FrequencyLibrary.frequencyLibrary)
        {
            float distance = Mathf.Abs(hertz - noteFrequency.Value);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestNote = noteFrequency.Key;
            }
        }

        return closestNote;
    }
}
