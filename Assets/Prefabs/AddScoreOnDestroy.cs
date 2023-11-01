using UnityEngine;

public class AddScoreOnDestroy : MonoBehaviour
{
    public int scoreToAdd = 1; // The score to add when the GameObject is destroyed
    private ScoreManager scoreManager; // Reference to the ScoreManager script

    void Start()
    {
        // Find the ScoreManager script in the scene
        scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager script not found in the scene!");
        }
    }

    void OnDestroy()
    {
        // Check if the ScoreManager script is found
        if (scoreManager != null)
        {
            // Add score when the GameObject is destroyed
            scoreManager.AddScore(scoreToAdd);
        }
    }
}