using UnityEngine;

public class RandomPositionSetter : MonoBehaviour
{
    public Transform[] targetPositions;

    void OnEnable()
    {       
            MoveToRandomPosition();
    }


    void MoveToRandomPosition()
    {
        if (targetPositions.Length > 0)
        {
            int randomIndex = Random.Range(0, targetPositions.Length);
            Transform randomTarget = targetPositions[randomIndex];
            transform.position = randomTarget.position;
        }
        else
        {
            Debug.LogError("No target positions assigned!");
        }
    }
}
