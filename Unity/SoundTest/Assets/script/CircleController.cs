using UnityEngine;
using UnityEngine.UI;

public class CircleController : MonoBehaviour
{
    public bool circle = false;
    public bool mic = false;
    public bool playMode = false;
    public bool recMode = false;
    public Shader circleShader; // シェーダーマテリアル

    public string note; // 音階名を格納する変数
    public float playTime;

    private RawImage rawImage; // RawImageコンポーネントの参照
    private Material circleMaterial; // マテリアルのインスタンス

    public float volume;
    public float targetVolumeCircle = 0.0f;
    private float currentVolumeCircle = 0.0f;

    public float innerChangeSpeed = 100.0f;
    public float outerChangeSpeed = 100.0f;
    public float collarChangeSpeed = 100.0f;

    private float preR = 255.0f;
    private float preG = 255.0f;
    private float preB = 255.0f;

    private float colR = 255.0f;
    private float colG = 255.0f;
    private float colB = 255.0f;

    private void Start()
    {
        // マテリアルのインスタンスを作成または既存のマテリアルを取得
        rawImage = GetComponent<RawImage>();
        circleMaterial = new Material(circleShader);

        // マテリアルをオブジェクトに適用
        rawImage.material = circleMaterial;
    }

    private void Update()
    {
        if(mic)
        {
            targetVolumeCircle = volume;
            preR = 0.1f + (0.9f * currentVolumeCircle);
            preG = 0.1f + (0.9f * currentVolumeCircle);
            preB = 0.1f + (0.9f * currentVolumeCircle);
        }
        else
        {
            if(circle)
            {
                targetVolumeCircle = volume;
                ColorChange();
                
            }
            else
            {
                targetVolumeCircle = 0.0f;
                preR = 0.1f + (0.9f * currentVolumeCircle);
                preG = 0.1f + (0.9f * currentVolumeCircle);
                preB = 0.1f + (0.9f * currentVolumeCircle);
            }
        }

        currentVolumeCircle = Mathf.Lerp(currentVolumeCircle, targetVolumeCircle, innerChangeSpeed * Time.deltaTime);

        colR = Mathf.Lerp(colR, preR, collarChangeSpeed * Time.deltaTime);
        colG = Mathf.Lerp(colG, preG, collarChangeSpeed * Time.deltaTime);
        colB = Mathf.Lerp(colB, preB, collarChangeSpeed * Time.deltaTime);

        rawImage.material.SetFloat("_PlayTime", playTime);
        rawImage.material.SetFloat("_Volume", currentVolumeCircle);
        rawImage.material.SetFloat("_R", colR);
        rawImage.material.SetFloat("_G", colG);
        rawImage.material.SetFloat("_B", colB);
    }

    void ColorChange()
    {
        if(NoteNameIdentification.A(note))
        {
            preR = 191;
            preG = 127;
            preB = 255;
        }
        else if(NoteNameIdentification.As(note))
        {
            preR = 255;
            preG = 127;
            preB = 255;
        }
        else if(NoteNameIdentification.B(note))
        {
            preR = 255;
            preG = 127;
            preB = 191;
        }
        else if(NoteNameIdentification.C(note))
        {
            preR = 255;
            preG = 127;
            preB = 127;
        }
        else if(NoteNameIdentification.Cs(note))
        {
            preR = 255;
            preG = 191;
            preB = 127;
        }
        else if(NoteNameIdentification.D(note))
        {
            preR = 255;
            preG = 255;
            preB = 127;
        }
        else if(NoteNameIdentification.Ds(note))
        {
            preR = 191;
            preG = 255;
            preB = 127;
        }
        else if(NoteNameIdentification.E(note))
        {
            preR = 127;
            preG = 255;
            preB = 127;
        }
        else if(NoteNameIdentification.F(note))
        {
            preR = 127;
            preG = 255;
            preB = 191;
        }
        else if(NoteNameIdentification.Fs(note))
        {
            preR = 127;
            preG = 255;
            preB = 255;
        }
        else if(NoteNameIdentification.G(note))
        {
            preR = 127;
            preG = 191;
            preB = 255;
        }
        else if(NoteNameIdentification.Gs(note))
        {
            preR = 127;
            preG = 127;
            preB = 255;
        }
        else
        {   
            preR = 127;
            preG = 127;
            preB = 127;
        }

        preR = preR / 255;
        preG = preG / 255;
        preB = preB / 255;
    }
}
