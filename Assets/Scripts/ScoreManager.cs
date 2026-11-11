using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;     // the text on screen
    public float maxGap = 1f;      // max seconds between top and bottom zone

    int score;
    float topTime = -10f;          // when the ball last touched the top zone

    void Start()
    {
        UpdateText();
    }

    public void BallEnteredTop()
    {
        topTime = Time.time;
    }

    public void BallEnteredBottom()
    {
        if (Time.time - topTime < maxGap)
        {
            score++;
            topTime = -10f;        // stops the same shot counting twice
            UpdateText();
        }
    }

    void UpdateText()
    {
        scoreText.text = "Score: " + score;
    }
}