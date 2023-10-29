using UnityEngine;
using UnityEngine.Events;

public class EventSplitter : MonoBehaviour
{
    public UnityEvent unityEvent1;
    public UnityEvent unityEvent2;

    public bool StartEvent1 = true;

    public bool isEvent1 = true;

    private void Start()
    {
        if (StartEvent1) 
        {
            isEvent1 = true;
        }
        else 
        {
            isEvent1 = false;
        }
    }
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
