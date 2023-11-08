using UnityEngine;
using DG.Tweening;
using System.Collections;

public class UiOscillatingMotionWithBPM : MonoBehaviour
{
    public float bpm = 120;
    public float amplitude = 1f;
    public float durationMultiplier = 1.5f;
    public Ease easeType = Ease.InOutSine;
    public bool isOffBeat = false;
    //public bool Started = false;
    public bool LateStart = false;
    [SerializeField]
    private GameObject DoTweenKilltarget;

    [SerializeField]
    private RectTransform rectTransform;

    private float halfBeatDuration;

    private Vector2 initialPosition;

    private void Start()
    {
        
        if (rectTransform == null)
        {
            Debug.LogError("RectTransform not assigned!");
            return;
        }

        // Store initial position relative to the parent's center
        initialPosition = rectTransform.anchoredPosition;
    }

    public void StartInstrument()
    {
        float beatDuration = 60f / bpm * durationMultiplier;
        Vector2 startPos = initialPosition;
        Vector2 endPos = startPos + Vector2.right * amplitude;

        if (isOffBeat)
        {
            // Mirror the motion in X-axis for offbeat
            endPos = startPos - Vector2.right * amplitude;
        }

        if (!isOffBeat)
        {
            Sequence offbeat = DOTween.Sequence();
            offbeat.AppendCallback(() => rectTransform.anchoredPosition = endPos);
            offbeat.Append(rectTransform.DOLocalMove(startPos, beatDuration).SetEase(easeType));

            offbeat.SetLoops(-1);
        }
        else
        {
            Sequence beat = DOTween.Sequence();
            beat.AppendCallback(() => rectTransform.anchoredPosition = endPos);
            beat.Append(rectTransform.DOLocalMove(startPos, beatDuration).SetEase(easeType));

            beat.SetLoops(-1);
        }
    }

    //public void StartOnce()
    //{
    //    if (Started == false)
    //    {
    //        StartInstrument();
    //        Started = true;
    //    }
    //}

    public void StopInstrument()
    {
        //Started = false;
        rectTransform.anchoredPosition = initialPosition;
        DOTween.KillAll();
    }

    public void RestartInstrument()
    {
        halfBeatDuration = (60f / bpm * durationMultiplier) / 2;
        rectTransform.anchoredPosition = initialPosition;
        DOTween.Kill(DoTweenKilltarget);
        if (LateStart)
        {
            StartCoroutine(StartThisLate(halfBeatDuration));
        }
        else 
        {
            StartInstrument();
        }
    }

    private IEnumerator StartThisLate(float duration)
    {
        float halfDuration = duration;
        yield return new WaitForSeconds(halfDuration);

        StartInstrument();
    }
}
