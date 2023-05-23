using UnityEngine;
using UnityEngine.UI;

public class WaveVisualizer : MonoBehaviour
{
    public GetAudioData audioData;
    public RawImage graphImage;
    public Color graphColor = Color.black;
    public Color backgroundColor = Color.white;

    private Texture2D graphTexture;

    void Start()
    {
        int dataLength = audioData.audioData.Length;
        graphTexture = new Texture2D(dataLength, 1, TextureFormat.RGBA32, false);
        graphImage.texture = graphTexture;
        ClearGraphTexture();
    }

    void Update()
    {
        UpdateGraphTexture();
    }

    void ClearGraphTexture()
    {
        Color[] pixels = new Color[graphTexture.width];
        for (int i = 0; i < graphTexture.width; i++)
        {
            pixels[i] = backgroundColor;
        }
        graphTexture.SetPixels(pixels);
        graphTexture.Apply();
    }

    void UpdateGraphTexture()
    {
        ClearGraphTexture();

        float graphHeight = graphImage.rectTransform.rect.height;
        float graphWidth = graphImage.rectTransform.rect.width;
        float dataWidth = graphWidth / audioData.audioData.Length;

        for (int i = 0; i < audioData.audioData.Length; i++)
        {
            float x = i * dataWidth;
            float y = audioData.audioData[i] * graphHeight / 2f;

            DrawGraphLine(x, y, dataWidth, graphHeight);
        }

        graphTexture.Apply();
    }

    void DrawGraphLine(float x, float y, float width, float height)
    {
        int startX = Mathf.FloorToInt(x);
        int endX = Mathf.CeilToInt(x + width);
        int startY = Mathf.FloorToInt(height / 2f);
        int endY = Mathf.CeilToInt(startY + y);

        for (int i = startX; i < endX; i++)
        {
            for (int j = startY; j < endY; j++)
            {
                if (i >= 0 && i < graphTexture.width && j >= 0 && j < graphTexture.height)
                {
                    graphTexture.SetPixel(i, j, graphColor);
                }
            }
        }
    }
}
