using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CircleGenerator : MonoBehaviour
{
    public GameObject circlePrefab; // Circleのプレハブ
    public ScoreRecorder scoreRecorder; // ScoreRecorderへの参照
    public GetAudioData audioData;

    public GameObject[] circles; // Circleの配列
    private RectTransform[] circlesTransform;

    public GameObject volumeObject;

    private float screenWidth;
    private float screenHeight;

    private float[] angle;
    private float[] distance;
    public float[] targetX, targetY;
    private float[] currentX,currentY;
    private float positionMoveSpeed = 1.0f;

    private bool resetPosition = false;

    private float targetCircleSize;
    private float currentCircleSize;
    private float circleSizeChangeSpeed = 100.0f;

    void Start()
    {
        scoreRecorder.Start();
        int scoreLength = scoreRecorder.score.Length; // Scoreの配列の長さ

        circles = new GameObject[scoreLength]; // Circleの配列を初期化
        circlesTransform = new RectTransform[scoreLength];

        angle = new float[scoreLength];
        distance = new float[scoreLength];
        targetX = new float[scoreLength];
        targetY = new float[scoreLength];
        currentX = new float[scoreLength];
        currentY = new float[scoreLength];

        // 画面の幅と高さを取得
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        // Circleの幅と高さを計算
        float circleSize = screenHeight / 2f;

        // グループの位置を計算
        Vector3 groupPosition = new Vector3(screenWidth / 2f, screenHeight / 2f, 0f);

        // Circleを生成し配置
        for (int i = 0; i < scoreLength; i++)
        {
            GameObject circle = Instantiate(circlePrefab, Vector3.zero, Quaternion.identity);
            circle.name = i.ToString(); // Circleの名前を設定

            // Circleの位置とサイズを設定
            RectTransform rectTransform = circle.GetComponent<RectTransform>();
            rectTransform.SetParent(transform, false); // グループの子要素にする
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f); // アンカーポイントを中央に設定
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.sizeDelta = new Vector2(circleSize, circleSize);
            rectTransform.anchoredPosition = new Vector2(0f, 0f); // グループの中央に配置
            
            circlesTransform[i] = rectTransform;
            circles[i] = circle; // 配列にCircleを格納
        }

        volumeObject.GetComponent<RectTransform>().sizeDelta = new Vector2(screenHeight, screenHeight);

        // グループの位置を設定
        transform.position = groupPosition;
    }

    void Update()
    {
        // Scoreの配列をチェックして必要な処理を行う
        for (int i = 0; i < circles.Length; i++)
        {
            CircleController circleController = circles[i].GetComponent<CircleController>();

            currentX[i] = Mathf.Lerp(currentX[i], targetX[i], positionMoveSpeed * Time.deltaTime);
            currentY[i] = Mathf.Lerp(currentY[i], targetY[i], positionMoveSpeed * Time.deltaTime);
            currentCircleSize = Mathf.Lerp(currentCircleSize, targetCircleSize, circleSizeChangeSpeed * Time.deltaTime);
            circlesTransform[i].sizeDelta = new Vector2(currentCircleSize, currentCircleSize);
            circlesTransform[i].anchoredPosition = new Vector2(currentX[i], currentY[i]);

            circleController.playTime = scoreRecorder.playTime[i];
            circleController.mic = scoreRecorder.mic;
            circleController.circle = scoreRecorder.playCheck[i];
            
            if(!scoreRecorder.mic)
            {
                if(scoreRecorder.playCheck[i])
                {
                    circleController.innerCircle = true;
                    

                    if(circleController.volume == 0)
                    {
                        circleController.note = scoreRecorder.nowMelodyNote; // 音階名を格納
                        circleController.volume = scoreRecorder.inputVolumes[i];

                        angle[i] = Angle(scoreRecorder.nowMelodyNote);
                        distance[i] = (screenHeight/18)*(1+NoteNameIdentification.Pitch(scoreRecorder.nowMelodyNote));

                        targetX[i] = distance[i]*Mathf.Sin(angle[i]*Mathf.PI/180f);
                        targetY[i] = distance[i]*Mathf.Cos(angle[i]*Mathf.PI/180f);

                    }

                    circleController.outerCircle = true;
                }
                else
                {
                    circleController.innerCircle = false;
                    circleController.note = ""; // ノートを初期化
                    circleController.volume = 0;
                    circleController.outerCircle = false;
                }

                resetPosition = true;
                
                targetCircleSize = screenHeight/4;

                circleController.targetVolumeCircle = 0.1f;

                
            }
            else
            {
                circleController.volume = scoreRecorder.inputVolumes[i];

                if(resetPosition)
                {
                    Array.Clear(targetX, 0, targetX.Length);
                    Array.Clear(targetY, 0, targetY.Length);
                    resetPosition = false;
                }
                targetCircleSize = screenHeight;

                if(UnityEngine.Random.Range(0,1000) >= 999)
                {
                    float randomSize = screenHeight/128;
                    targetX[i] = UnityEngine.Random.Range(-randomSize, randomSize);
                    targetY[i] = UnityEngine.Random.Range(-randomSize, randomSize);
                }
            }
        }
    }

    private int Angle(string note)
    {
        if(NoteNameIdentification.A(note))
        {
            return 0;
        }
        else if(NoteNameIdentification.As(note))
        {
            return 30;
        }
        else if(NoteNameIdentification.B(note))
        {
            return 60;
        }
        else if(NoteNameIdentification.C(note))
        {
            return 90;
        }
        else if(NoteNameIdentification.Cs(note))
        {
            return 120;
        }
        else if(NoteNameIdentification.D(note))
        {
            return 150;
        }
        else if(NoteNameIdentification.Ds(note))
        {
           return 180;
        }
        else if(NoteNameIdentification.E(note))
        {
            return 210;
        }
        else if(NoteNameIdentification.F(note))
        {
            return 240;
        }
        else if(NoteNameIdentification.Fs(note))
        {
            return 270;
        }
        else if(NoteNameIdentification.G(note))
        {
            return 300;
        }
        else if(NoteNameIdentification.Gs(note))
        {
            return 330;
        }

        return 0;
    }
}
