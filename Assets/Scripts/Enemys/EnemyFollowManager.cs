using UnityEngine;

public class EnemyFollowManager : MonoBehaviour
{
    void Start()
    {
        // Call StopAll() method at the start if needed
        // StopAll();
    }

    public void StopAll()
    {
        EnemyFollow[] enemies = FindObjectsByType<EnemyFollow>(FindObjectsSortMode.None);

        foreach (EnemyFollow enemy in enemies)
        {
            enemy.chaseSpeed = 0f;
        }
    }

    public void ResumeAll()
    {
        EnemyFollow[] enemies = FindObjectsByType<EnemyFollow>(FindObjectsSortMode.None);

        foreach (EnemyFollow enemy in enemies)
        {
            enemy.chaseSpeed = 3f;
        }
    }
}
