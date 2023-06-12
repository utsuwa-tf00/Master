using UnityEngine;
using UnityEngine.UI;

public class CircleGenerator : MonoBehaviour
{
    public GameObject circlePrefab; // Circleのプレハブ
    public ScoreRecorder scoreRecorder; // ScoreRecorderへの参照

    private GameObject[] circles; // Circleの配列

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
            GameObject circle = circles[i];
            // サンプルとして、Scoreの値に応じてCircleの色を変える処理を行う
            Image circleImage = circle.GetComponent<Image>();
            if (string.IsNullOrEmpty(scoreRecorder.score[i]))
            {
                //circleImage.color = Color.white;
            }
            else
            {
                //circleImage.color = Color.green;
            }
        }
    }
}
