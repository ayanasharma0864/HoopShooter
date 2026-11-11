using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text messageText;
    public float gameTime = 60f;
    public float maxGap = 1f;

    public AudioSource audioSource;
    public AudioClip swishClip;
    public AudioClip buzzerClip;

    int score;
    float topTime = -10f;
    float timeLeft;
    bool gameOver;

    void Start()
    {
        timeLeft = gameTime;
        messageText.text = "";
        UpdateText();
    }

    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            gameOver = true;
            if (buzzerClip != null && audioSource != null)
                audioSource.PlayOneShot(buzzerClip);
            messageText.text = "TIME UP!\nFinal Score: " + score + "\nPress R to restart";
        }
        UpdateText();
    }

    public bool IsGameOver() { return gameOver; }

    public void BallEnteredTop()
    {
        if (gameOver) return;
        topTime = Time.time;
    }

    public void BallEnteredBottom()
    {
        if (gameOver) return;
        if (Time.time - topTime < maxGap)
        {
            score++;
            topTime = -10f;
            if (swishClip != null && audioSource != null)
                audioSource.PlayOneShot(swishClip);
        }
    }

    void UpdateText()
    {
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);
    }
}