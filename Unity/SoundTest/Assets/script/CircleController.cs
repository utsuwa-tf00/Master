using UnityEngine;
using UnityEngine.UI;

public class CircleController : MonoBehaviour
{
    public bool innerCircle = false; // 制御トグル
    public bool outerCircle = false;
    public bool circle = false;
    public bool mic = false;
    public Shader circleShader; // シェーダーマテリアル

    public string note; // 音階名を格納する変数
    public float playTime;

    private RawImage rawImage; // RawImageコンポーネントの参照
    private Material circleMaterial; // マテリアルのインスタンス

    private float targetInnerCircle = 0.0f;
    private float currentInnerCircle = 0.0f;

    public float volume;
    public float targetVolumeCircle = 0.0f;
    private float currentVolumeCircle = 0.0f;

    /*
    private float targetOuter1Circle = 0.0f;
    private float currentOuter1Circle = 0.0f;
    private float targetOuter2Circle = 0.0f;
    private float currentOuter2Circle = 0.0f;
    private float targetOuter3Circle = 0.0f;
    private float currentOuter3Circle = 0.0f;
    private float targetOuter4Circle = 0.0f;
    private float currentOuter4Circle = 0.0f;
    */

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
        /*
        // innerCircleの値の設定
        if (innerCircle)
        {
            //targetInnerCircle = 0.1f;
            targetVolumeCircle = volume;
        }
        else
        {
            //targetInnerCircle = 0.0f;
            targetVolumeCircle = 0.0f;
        }

        // outer1Circleの値の設定
        if (outerCircle)
        {
            
            targetOuter1Circle = 0.25f;
            targetOuter2Circle = 0.35f;
            targetOuter3Circle = 0.35f;
            targetOuter4Circle = 0.45f;
        }
        else
        {
            
            targetOuter1Circle = 0.0f;
            targetOuter2Circle = 0.0f;
            targetOuter3Circle = 0.0f;
            targetOuter4Circle = 0.0f;
        }
        */

        //currentInnerCircle = Mathf.Lerp(currentInnerCircle, targetInnerCircle, innerChangeSpeed * Time.deltaTime);
        currentVolumeCircle = Mathf.Lerp(currentVolumeCircle, targetVolumeCircle, innerChangeSpeed * Time.deltaTime);
        /*
        currentOuter1Circle = Mathf.Lerp(currentOuter1Circle, targetOuter1Circle, outerChangeSpeed * Time.deltaTime);
        currentOuter2Circle = Mathf.Lerp(currentOuter2Circle, targetOuter2Circle, outerChangeSpeed * Time.deltaTime);
        currentOuter3Circle = Mathf.Lerp(currentOuter3Circle, targetOuter3Circle, outerChangeSpeed * Time.deltaTime);
        currentOuter4Circle = Mathf.Lerp(currentOuter4Circle, targetOuter4Circle, outerChangeSpeed * Time.deltaTime);
        */
        colR = Mathf.Lerp(colR, preR, collarChangeSpeed * Time.deltaTime);
        colG = Mathf.Lerp(colG, preG, collarChangeSpeed * Time.deltaTime);
        colB = Mathf.Lerp(colB, preB, collarChangeSpeed * Time.deltaTime);

        rawImage.material.SetFloat("_PlayTime", playTime);
        //rawImage.material.SetFloat("_InnerCircle", currentInnerCircle);
        rawImage.material.SetFloat("_Volume", currentVolumeCircle);
        /*
        rawImage.material.SetFloat("_Outer1Circle", currentOuter1Circle);
        rawImage.material.SetFloat("_Outer2Circle", currentOuter2Circle);
        rawImage.material.SetFloat("_Outer3Circle", currentOuter3Circle);
        rawImage.material.SetFloat("_Outer4Circle", currentOuter4Circle);
        */
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
