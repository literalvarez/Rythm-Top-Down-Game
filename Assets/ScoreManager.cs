using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    // Method to add score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Update the TextMeshPro component to display the current score
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: \n" + score;
        }
    }
}
