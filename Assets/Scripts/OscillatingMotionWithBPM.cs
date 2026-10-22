using UnityEngine;
using DG.Tweening;

public class OscillatingMotionWithBPM : MonoBehaviour
{
    public float bpm = 120;
    public float amplitude = 1f;
    public float durationMultiplier = 1.5f;
    public Ease easeType = Ease.InOutSine;
    public bool isOffBeat = false;
    public bool Started = false;

    private Vector2 initialPosition;
    private Sequence loopSequence; // The running oscillation, so we only kill our own tween

    private void Start()
    {
        initialPosition = transform.position;
    }

    public void StartInstrument()
    {
        float beatDuration = 60f / bpm * durationMultiplier;
        Vector2 startPos = transform.position;
        Vector2 endPos = startPos + Vector2.right * amplitude;

        if (isOffBeat)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y);
            startPos = transform.position;
            endPos = startPos + Vector2.left * amplitude;
        }

        loopSequence?.Kill();
        loopSequence = DOTween.Sequence();
        loopSequence.AppendCallback(() => transform.localPosition = endPos);
        loopSequence.Append(transform.DOLocalMove(startPos, beatDuration).SetEase(easeType));
        loopSequence.SetLoops(-1);
    }

    public void StartOnce()
    {
        if (Started == false)
        {
            StartInstrument();
            Started = true;
        }
    }    


    public void StopInstrument()
    {
        Started = false;
        loopSequence?.Kill();
        transform.position = initialPosition;
    }

    public void RestartInstrument()
    {
        loopSequence?.Kill();
        transform.position = initialPosition;
        StartInstrument();
    }

    private void OnDestroy()
    {
        loopSequence?.Kill();
    }
}
