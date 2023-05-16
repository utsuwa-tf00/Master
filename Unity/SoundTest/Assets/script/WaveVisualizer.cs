using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveVisualizer : MonoBehaviour
{
    public RawImage waveformImage;
    public Color waveformColor;
    public float scaleFactor = 1f;
    public float cutoff = 0.001f;
    public float thickness = 0.02f;

    private Texture2D waveformTexture;
    private Color[] waveformColors;

    [Range(0.0f, 1.0f)]
    public float scrollSpeed = 1.0f; // 追加: 波形の流れる速度を制御する変数

    private float scrollOffset = 0.0f; // 追加: 波形の流れるオフセットを保持する変数

    void Start()
    {
        // Create waveform texture
        waveformTexture = new Texture2D((int)waveformImage.rectTransform.rect.width, (int)waveformImage.rectTransform.rect.height);
        waveformTexture.filterMode = FilterMode.Point;
        waveformTexture.wrapMode = TextureWrapMode.Clamp;
        waveformImage.texture = waveformTexture;

        // Initialize waveform colors
        waveformColors = new Color[waveformTexture.width * waveformTexture.height];
        for (int i = 0; i < waveformColors.Length; i++)
        {
            waveformColors[i] = Color.clear;
        }

        // Subscribe to AudioCaptured event
        GetAudio.AudioCaptured += OnAudioCaptured;
    }

    void Update()
    {
        // Get audio waveform data from GetAudio script
        float[] samples = GetAudio.audioSamples;

        // Check if samples array is empty
        if (samples == null || samples.Length == 0)
        {
            return;
        }

        // Calculate number of samples per pixel based on waveform texture width
        int samplesPerPixel = Mathf.Max(1, Mathf.FloorToInt(samples.Length / waveformTexture.width));

        // Reset waveform colors to clear
        for (int i = 0; i < waveformColors.Length; i++)
        {
            waveformColors[i] = Color.clear;
        }

        // Calculate the scroll offset based on scrollSpeed
        scrollOffset += Time.deltaTime * scrollSpeed;

        // Draw waveform on texture
        for (int i = 0; i < waveformTexture.width; i++)
        {
            // Calculate start and end sample indices for current pixel
            int startSample = (int)(i * samplesPerPixel + scrollOffset);
            int endSample = (int)((i + 1) * samplesPerPixel + scrollOffset) - 1;

            // Calculate average sample value for current pixel
            float averageSample = 0f;
            for (int j = startSample; j <= endSample; j++)
            {
                averageSample += Mathf.Abs(samples[j]);
            }
            averageSample /= samplesPerPixel;

            // Apply cutoff to eliminate noise
            if (averageSample < cutoff)
            {
                averageSample = 0f;
            }

            // Draw waveform on texture
            int waveformHeight = Mathf.RoundToInt(averageSample * waveformTexture.height * scaleFactor);
            for (int j = 0; j < waveformHeight; j++)
            {
                int index = j * waveformTexture.width + i;
                waveformColors[index] = waveformColor;
            }

            // Draw waveform thickness
            for (int j = 1; j <= Mathf.CeilToInt(thickness * waveformTexture.height); j++)
            {
                int index = (waveformHeight + j) * waveformTexture.width + i;
                waveformColors[index] = waveformColor;
            }
        }

        // Update waveform texture
        waveformTexture.SetPixels(waveformColors);
        waveformTexture.Apply();
    }

    void OnAudioCaptured(float[] audioSamples)
    {
        GetAudio.audioSamples = audioSamples;
    }
}
