using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

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

    private float xpSliderLerpSpeed = 5f;


    [SerializeField]
    private Ease easeType = Ease.OutQuad;

    [SerializeField]
    private float growTime = 0.5f;

    [SerializeField]
    private float shrinkTime = 0.5f;

    [SerializeField]
    private Vector2 growScale = new Vector2(1.2f, 1.2f);

    [SerializeField]
    private Vector2 originalScale = new Vector2(1f, 1f);

    void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if (xpSlider != null)
        {
            UpdateXpBar();
        }
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
            scoreText.text = "" + score;

            // Use DoTween to animate the scale of the text
            scoreText.transform.DOScale(growScale, growTime) // Grow to specified scale over specified time
                .SetEase(easeType)
                .OnComplete(() =>
                {
                    // Shrink back to original size after the growth animation completes
                    scoreText.transform.DOScale(originalScale, shrinkTime) // Shrink to original scale over specified time
                        .SetEase(easeType);
                });
        }

        if (levelText != null)
        {
            levelText.text = "Level: " + currentLevel;
        }

        if (xpInfoText != null)
        {
            xpInfoText.text = "XP: " + currentLevelXP + " / " + xpRequired + " XP to Level Up";
        }

    }

    void UpdateXpBar() 
    {
        xpSlider.value = Mathf.Lerp(xpSlider.value, currentLevelXP, Time.deltaTime * xpSliderLerpSpeed);
        xpSlider.maxValue = xpRequired;
    }
}
