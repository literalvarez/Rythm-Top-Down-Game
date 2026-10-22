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
    private Sequence loopSequence; // The running oscillation, so we can stop it on song changes
    private Coroutine lateStartCoroutine;

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

        loopSequence?.Kill();
        loopSequence = DOTween.Sequence();
        loopSequence.AppendCallback(() => rectTransform.anchoredPosition = endPos);
        loopSequence.Append(rectTransform.DOAnchorPos(startPos, beatDuration).SetEase(easeType));
        loopSequence.SetLoops(-1);
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
        StopLoop();
        rectTransform.anchoredPosition = initialPosition;

    }

    public void RestartInstrument()
    {
        halfBeatDuration = (60f / bpm * durationMultiplier) / 2;
        StopLoop();
        rectTransform.anchoredPosition = initialPosition;
        if (LateStart)
        {
            lateStartCoroutine = StartCoroutine(StartThisLate(halfBeatDuration));
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

        lateStartCoroutine = null;
        StartInstrument();
    }

    // Stops this object's oscillation (and a pending late start) without touching other tweens
    private void StopLoop()
    {
        if (lateStartCoroutine != null)
        {
            StopCoroutine(lateStartCoroutine);
            lateStartCoroutine = null;
        }
        loopSequence?.Kill();
        loopSequence = null;
        if (DoTweenKilltarget != null)
        {
            DOTween.Kill(DoTweenKilltarget);
        }
    }

    private void OnDestroy()
    {
        loopSequence?.Kill();
    }
}
