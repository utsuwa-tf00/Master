using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeVisualizer : MonoBehaviour
{
    public ScoreRecorder scoreRecorder; // ScoreRecorderへの参照
    public GetAudioData audioData;
    public DynamicAudioGeneration dynamicAudioGeneration;

    public Material volumeMaterial;
    private float targetVolume;
    private float currentVolume;

    private float thickness;

    private float volumeChangeSpeed = 100.0f;
    private float thicknessChangeSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreRecorder.mic)
        {
            if(audioData.loudness*scoreRecorder.volumeLeverage >= 1)targetVolume = 1;
            else targetVolume = audioData.loudness*scoreRecorder.volumeLeverage;
            currentVolume = Mathf.Lerp(currentVolume, targetVolume, volumeChangeSpeed * Time.deltaTime);
            thickness = Mathf.Lerp(thickness, targetVolume, thicknessChangeSpeed * Time.deltaTime);
            
            volumeMaterial.SetFloat("_Volume", currentVolume);
            volumeMaterial.SetFloat("_VolumeThickness", thickness);
        }
        else
        {
            if(scoreRecorder.nowMelodyVolume >= 1)targetVolume = 1;
            else if(scoreRecorder.nowMelodyVolume == 0)targetVolume = currentVolume;
            else targetVolume = scoreRecorder.nowMelodyVolume;
            
            currentVolume = Mathf.Lerp(currentVolume, targetVolume, volumeChangeSpeed * Time.deltaTime);
            thickness = Mathf.Lerp(thickness, targetVolume, thicknessChangeSpeed * Time.deltaTime);
            
            volumeMaterial.SetFloat("_Volume", currentVolume);
            volumeMaterial.SetFloat("_VolumeThickness", thickness);
        }
    }
}
