using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleGenerator : MonoBehaviour
{
    public GameObject circlePrefab; // Circleのプレハブ
    public ScoreRecorder scoreRecorder; // ScoreRecorderへの参照
    public GetAudioData audioData;

    public List<GameObject> circles = new List<GameObject>(); // Circleの配列
    private List<RectTransform> circlesTransform = new List<RectTransform>();

    public GameObject volumeObject;

    private List<CircleController> circleController = new List<CircleController>();

    private float screenWidth;
    private float screenHeight;

    private float[] angle;
    private float[] distance;
    public float[] targetX, targetY;
    private float[] currentX,currentY;
    private float positionMoveSpeed = 1.0f;

    private bool resetPosition = false;

    private float[] targetCircleSize;
    private float[] currentCircleSize;
    private float circleSizeChangeSpeed = 100.0f;

    void Start()
    {
        scoreRecorder.Start();
        int scoreLength = scoreRecorder.numberOfBars * scoreRecorder.beat * 4; // Scoreの配列の長さ

        angle = new float[scoreLength];
        distance = new float[scoreLength];
        targetX = new float[scoreLength];
        targetY = new float[scoreLength];
        currentX = new float[scoreLength];
        currentY = new float[scoreLength];

        targetCircleSize = new float[scoreLength];
        currentCircleSize = new float[scoreLength];

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
            
            circlesTransform.Add(rectTransform);
            circles.Add(circle); // 配列にCircleを格納
            circleController.Add(circle.GetComponent<CircleController>());
            circleController[i].recMode = true;
        }

        volumeObject.GetComponent<RectTransform>().sizeDelta = new Vector2(screenHeight, screenHeight);

        // グループの位置を設定
        transform.position = groupPosition;
    }

    void Update()
    {
        if(scoreRecorder.mic)
        {
            for(int micOn = 0; micOn < (scoreRecorder.numberOfBars * scoreRecorder.beat * 4); micOn++)
            {
                if(scoreRecorder.volumeScore.Count == 0)circleController[micOn].volume = 0;
                
                if(circleController[micOn].recMode)
                {
                    targetX[micOn] = 0;
                    targetY[micOn] = 0;
                    circleController[micOn].recMode = false;
                }

                targetCircleSize[micOn] = screenHeight;
                circleController[micOn].note = "";

                if(UnityEngine.Random.Range(0,1000) >= 999)
                {
                    float randomSize = screenHeight/128;
                    targetX[micOn] = UnityEngine.Random.Range(-randomSize, randomSize);
                    targetY[micOn] = UnityEngine.Random.Range(-randomSize, randomSize);
                }

                if(scoreRecorder.volumeScore.Count == 0)circleController[micOn].volume = 0;
                circleController[micOn].playMode = true;
            }

            

            for(int volSize = 0; volSize < scoreRecorder.volumeScore.Count; volSize++)
            {
                circleController[volSize].volume = scoreRecorder.volumeScore[volSize];
            }
        }
        else
        {
            for(int micOff = 0; micOff < (scoreRecorder.numberOfBars * scoreRecorder.beat * 4); micOff++)
            {
                targetCircleSize[micOff] = screenHeight/4;
                circleController[micOff].note = scoreRecorder.melodyScore[micOff];

                if(scoreRecorder.playCheck[micOff] && circleController[micOff].playMode)
                {
                    circleController[micOff].volume = scoreRecorder.volumeScore[micOff];

                    angle[micOff] = Angle(scoreRecorder.melodyScore[micOff]);
                    distance[micOff] = (screenHeight/18)*(1+NoteNameIdentification.Pitch(scoreRecorder.melodyScore[micOff]));

                    targetX[micOff] = distance[micOff]*Mathf.Sin(angle[micOff]*Mathf.PI/180f);
                    targetY[micOff] = distance[micOff]*Mathf.Cos(angle[micOff]*Mathf.PI/180f);
                    circleController[micOff].playMode = false;
                }

                circleController[micOff].recMode = true;
            }
        }

        for(int pos = 0; pos < circles.Count; pos++)
        {
            currentX[pos] = Mathf.Lerp(currentX[pos], targetX[pos], positionMoveSpeed * Time.deltaTime);
            currentY[pos] = Mathf.Lerp(currentY[pos], targetY[pos], positionMoveSpeed * Time.deltaTime);

            currentCircleSize[pos] = Mathf.Lerp(currentCircleSize[pos], targetCircleSize[pos], circleSizeChangeSpeed * Time.deltaTime);

            circlesTransform[pos].sizeDelta = new Vector2(currentCircleSize[pos], currentCircleSize[pos]);
            circlesTransform[pos].anchoredPosition = new Vector2(currentX[pos], currentY[pos]);

            circleController[pos].playTime = 1;
            circleController[pos].mic = scoreRecorder.mic;
            circleController[pos].circle = scoreRecorder.playCheck[pos];
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
