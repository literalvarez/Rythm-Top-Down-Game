using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI xpInfoText;
    public Slider xpSlider;
    public UnityEvent onLevelUp; // UnityEvent to trigger when leveling up

    public int score = 0;
    public int currentLevel = 1;
    public int xpRequired = 10;
    private int currentLevelXP = 0; // XP points gained within the current level

    void Start()
    {
        UpdateUI();
    }

    // Method to add score
    public void AddScore(int points)
    {
        score += points;
        currentLevelXP += points; // Track XP gained within the current level

        // Check if the player has gained enough XP to level up
        if (currentLevelXP >= xpRequired)
        {
            LevelUp();
        }

        UpdateUI();
    }

    // Level up the player
    void LevelUp()
    {
        currentLevel++;
        currentLevelXP = 0; // Reset XP points within the current level to 0
        xpRequired *= 2; // Double the XP requirement for the next level
        onLevelUp.Invoke(); // Trigger UnityEvent when leveling up
        xpSlider.value = 0; // Reset the XP slider to 0
    }

    // Update the UI elements to display current score, level, XP progress, and requirements
    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

        if (levelText != null)
        {
            levelText.text = "Level: " + currentLevel;
        }

        if (xpInfoText != null)
        {
            xpInfoText.text = "XP: " + currentLevelXP + " / " + xpRequired + " XP to Level Up";
        }

        if (xpSlider != null)
        {
            xpSlider.maxValue = xpRequired;
            xpSlider.value = currentLevelXP;
        }
    }
}
