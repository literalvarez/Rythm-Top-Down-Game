using System.Collections;
using TMPro;
using UnityEngine;

public class SongChangerTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float countdownDuration = 5f;

    private bool isCountdownActive = false;

    private void OnEnable()
    {
        if (!isCountdownActive)
        {
            StartCountdown();
            isCountdownActive = true;
        }
    }

    public void StartCountdown()
    {
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        countdownText.gameObject.SetActive(true);

        float timeLeft = countdownDuration;

        while (timeLeft > 0)
        {
            countdownText.text = "NEXT SONG\n" + Mathf.Ceil(timeLeft).ToString();
            timeLeft -= Time.deltaTime;
            yield return null;
        }

        countdownText.text = "NEXT SONG\n0";
        countdownText.gameObject.SetActive(false);

        isCountdownActive = false; // Reset the flag so the countdown can happen again if the GameObject is re-enabled
    }
}
