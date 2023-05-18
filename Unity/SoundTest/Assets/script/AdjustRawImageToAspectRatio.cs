using UnityEngine;
using UnityEngine.UI;

public class AdjustRawImageToAspectRatio : MonoBehaviour
{
    public RawImage rawImage;

    void Start()
    {
        if (rawImage.texture != null)
        {
            float screenAspect = (float)Screen.width / Screen.height;
            float textureAspect = (float)rawImage.texture.width / rawImage.texture.height;

            if (screenAspect > textureAspect)
            {
                float scaledHeight = Screen.width / textureAspect;
                rawImage.rectTransform.sizeDelta = new Vector2(Screen.width, scaledHeight);
            }
            else
            {
                float scaledWidth = Screen.height * textureAspect;
                rawImage.rectTransform.sizeDelta = new Vector2(scaledWidth, Screen.height);
            }
        }
    }
}
