using UnityEngine;
using UnityEngine.UI;

public class CircleController : MonoBehaviour
{
    public bool innerCircle = false; // 制御トグル
    public bool outerCircle = false;
    public Shader circleShader; // シェーダーマテリアル

    public string note; // 音階名を格納する変数

    private RawImage rawImage; // RawImageコンポーネントの参照
    private Material circleMaterial; // マテリアルのインスタンス

    private float targetInnerCircle = 0.0f; // 目標のbaseCircle値
    private float currentInnerCircle = 0.0f; // 現在のbaseCircle値
    private float targetOuterCircle = 0.0f; // 目標のbaseCircle値
    private float currentOuterCircle = 0.0f; // 現在のbaseCircle値
    public float innerChangeSpeed = 100.0f; // baseCircleの変化速度 
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
        if (rawImage.material.HasProperty("_BaseCircle"))
        {
            // 目標のbaseCircle値を設定
            if (innerCircle)
            {
                targetInnerCircle = 0.1f;
            }
            else
            {
                targetInnerCircle = 0.01f;
            }

            // 現在のbaseCircle値を滑らかに変化させる
            currentInnerCircle = Mathf.Lerp(currentInnerCircle, targetInnerCircle, innerChangeSpeed * Time.deltaTime);

            // baseCircle値をマテリアルに設定
            rawImage.material.SetFloat("_BaseCircle", currentInnerCircle);
        }

        if (rawImage.material.HasProperty("_Radius"))
        {
            if (outerCircle)
            {
                targetOuterCircle = 0.45f;
            }
            else
            {
                targetOuterCircle = 0.0f;
            }

            currentOuterCircle = Mathf.Lerp(currentOuterCircle, targetOuterCircle, outerChangeSpeed * Time.deltaTime);

            rawImage.material.SetFloat("_Radius", currentOuterCircle);
        }

        if(rawImage.material.HasProperty("_R") && rawImage.material.HasProperty("_G") && rawImage.material.HasProperty("_B"))
        {
            if(outerCircle)
            {
                ColorChange();
            }
            else
            {
                preR = 255;
                preG = 255;
                preB = 255;
            }
            
            colR = Mathf.Lerp(colR, preR, collarChangeSpeed * Time.deltaTime);
            colG = Mathf.Lerp(colG, preG, collarChangeSpeed * Time.deltaTime);
            colB = Mathf.Lerp(colB, preB, collarChangeSpeed * Time.deltaTime);

            rawImage.material.SetFloat("_R", colR);
            rawImage.material.SetFloat("_G", colG);
            rawImage.material.SetFloat("_B", colB);
        }
    }

    void ColorChange()
    {
        if(note == "A0" || note == "A1" || note == "A2" || note == "A3" || note == "A4" || note == "A5" || note == "A6" || note == "A7")
        {
            preR = 191;
            preG = 127;
            preB = 255;
        }
        else if(note == "A#0" || note == "A#1" || note == "A#2" || note == "A#3" || note == "A#4" || note == "A#5" || note == "A#6" || note == "A#7")
        {
            preR = 255;
            preG = 127;
            preB = 255;
        }
        else if(note == "B0" || note == "B1" || note == "B2" || note == "B3" || note == "B4" || note == "B5" || note == "B6" || note == "B7")
        {
            preR = 255;
            preG = 127;
            preB = 191;
        }
        else if(note == "C1" || note == "C2" || note == "C3" || note == "C4" || note == "C5" || note == "C6" || note == "C7" || note == "C8")
        {
            preR = 255;
            preG = 127;
            preB = 127;
        }
        else if(note == "C#1" || note == "C#2" || note == "C#3" || note == "C#4" || note == "C#5" || note == "C#6" || note == "C#7")
        {
            preR = 255;
            preG = 191;
            preB = 127;
        }
        else if(note == "D1" || note == "D2" || note == "D3" || note == "D4" || note == "D5" || note == "D6" || note == "D7")
        {
            preR = 255;
            preG = 255;
            preB = 127;
        }
        else if(note == "D#1" || note == "D#2" || note == "D#3" || note == "D#4" || note == "D#5" || note == "D#6" || note == "D#7")
        {
            preR = 191;
            preG = 255;
            preB = 127;
        }
        else if(note == "E1" || note == "E2" || note == "E3" || note == "E4" || note == "E5" || note == "E6" || note == "E7")
        {
            preR = 127;
            preG = 255;
            preB = 127;
        }
        else if(note == "F1" || note == "F2" || note == "F3" || note == "F4" || note == "F5" || note == "F6" || note == "F7")
        {
            preR = 127;
            preG = 255;
            preB = 191;
        }
        else if(note == "F#1" || note == "F#2" || note == "F#3" || note == "F#4" || note == "F#5" || note == "F#6" || note == "F#7")
        {
            preR = 127;
            preG = 255;
            preB = 255;
        }
        else if(note == "G1" || note == "G2" || note == "G3" || note == "G4" || note == "G5" || note == "G6" || note == "G7")
        {
            preR = 127;
            preG = 191;
            preB = 255;
        }
        else if(note == "G#1" || note == "G#2" || note == "G#3" || note == "G#4" || note == "G#5" || note == "G#6" || note == "G#7")
        {
            preR = 127;
            preG = 127;
            preB = 255;
        }
        else
        {   
            preR = 255;
            preG = 255;
            preB = 255;
        }

        preR = preR / 255;
        preG = preG / 255;
        preB = preB / 255;
    }
}
