using UnityEngine;
using UnityEngine.UI;

public class CircleGenerator : MonoBehaviour
{
    public GameObject circlePrefab; // Circleのプレハブ
    public ScoreRecorder scoreRecorder; // ScoreRecorderへの参照

    public GameObject[] circles; // Circleの配列

    void Start()
    {
        int scoreLength = scoreRecorder.score.Length; // Scoreの配列の長さ

        circles = new GameObject[scoreLength]; // Circleの配列を初期化

        // 画面の幅を取得
        float screenWidth = Screen.width;

        // Circleの幅を計算
        float circleWidth = screenWidth / scoreLength;

        // グループの位置を計算
        Vector3 groupPosition = transform.position;

        // Circleを生成し配置
        for (int i = 0; i < scoreLength; i++)
        {
            GameObject circle = Instantiate(circlePrefab, Vector3.zero, Quaternion.identity);
            circle.name = i.ToString(); // Circleの名前を設定

            // Circleの位置とサイズを設定
            RectTransform rectTransform = circle.GetComponent<RectTransform>();
            rectTransform.SetParent(transform, false); // グループの子要素にする
            rectTransform.anchorMin = new Vector2(0f, 0.5f);
            rectTransform.anchorMax = new Vector2(0f, 0.5f);
            rectTransform.pivot = new Vector2(0f, 0.5f);
            rectTransform.sizeDelta = new Vector2(circleWidth, circleWidth);
            rectTransform.anchoredPosition = new Vector2(i * circleWidth, 0f);

            circles[i] = circle; // 配列にCircleを格納
        }

        // グループの位置を設定
        transform.position = groupPosition;
    }

    void Update()
    {
        // Scoreの配列をチェックして必要な処理を行う
        for (int i = 0; i < circles.Length; i++)
        {
            CircleController circleController = circles[i].GetComponent<CircleController>();

            // 配列にデータが入っているかどうかでinnerCircleを設定
            if (string.IsNullOrEmpty(scoreRecorder.score[i]))
            {
                circleController.innerCircle = false;
                circleController.note = ""; // ノートを初期化
            }
            else
            {
                circleController.innerCircle = true;
                circleController.note = scoreRecorder.score[i]; // 音階名を格納
            }

            if(scoreRecorder.playCheck[i])
            {
                circleController.outerCircle = true;
            }
            else
            {
                circleController.outerCircle = false;
            }
        }
    }
}
