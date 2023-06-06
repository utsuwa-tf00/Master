using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public ScoreRecorder scoreRecorder;
    public Text scoreText;

    private void Update()
    {
        DisplayScore();
    }

    private void DisplayScore()
    {
        string displayText = string.Empty;

        for (int i = 0; i < scoreRecorder.score.Length; i++)
        {
            string noteName = scoreRecorder.score[i];

            if (string.IsNullOrEmpty(noteName))
            {
                displayText += "--";
            }
            else
            {
                displayText += noteName;
            }

            if (i < scoreRecorder.score.Length - 1)
            {
                displayText += " ";
            }
        }

        scoreText.text = displayText;
    }
}
