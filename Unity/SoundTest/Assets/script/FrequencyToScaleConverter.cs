using UnityEngine;

public class FrequencyToScaleConverter : MonoBehaviour
{
    public string scale; // Converted scale value (note name)

    private GetAudioData audioData; // Reference to the GetAudioData script

    private float[] recentFreq = new float[256];

    void Start()
    {
        audioData = GetComponent<GetAudioData>(); // Get the GetAudioData script from the same GameObject
    }

    void Update()
    {
        for(int rf = 0; rf < recentFreq.Length; rf++)
        {
            if(rf < recentFreq.Length-1)
            {
                recentFreq[rf + 1] = recentFreq[rf];
            }
        }

        float frequency = audioData.frequency; // Get the frequency from the GetAudioData script
        
        recentFreq[0] = frequency;

        float freqAverage = 0;
        float sumFreq = 0;

        for(int fa = 0; fa < recentFreq.Length; fa++)
        {
            sumFreq += recentFreq[fa];
        }

        freqAverage = sumFreq / 256;

        scale = ConvertHertzToScale(freqAverage); // Convert frequency to scale (note name)
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
