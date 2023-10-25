using UnityEngine;
using UnityEngine.Events;

public class EventSplitter : MonoBehaviour
{
    public UnityEvent unityEvent1;
    public UnityEvent unityEvent2;

    private bool isEvent1 = true;

    public void EventSplitterMethod()
    {
        if (isEvent1)
        {
            unityEvent1.Invoke();
        }
        else
        {
            unityEvent2.Invoke();
        }

        // Alternate between the two events
        isEvent1 = !isEvent1;
    }
}
