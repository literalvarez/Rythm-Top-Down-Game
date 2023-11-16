using UnityEngine;
using UnityEngine.Events;

public class DoOnEnable : MonoBehaviour
{
    // Declare UnityEvent
    public UnityEvent DoOnEnableEvent;

    private void OnEnable()
    {
        // Check if the UnityEvent is assigned
        if (DoOnEnableEvent != null)
        {
            // Invoke the UnityEvent
            DoOnEnableEvent.Invoke();
        }
    }
}
