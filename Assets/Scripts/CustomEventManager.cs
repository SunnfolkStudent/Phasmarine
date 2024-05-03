using UnityEngine;
using UnityEngine.Events;

public class CustomEventManager : MonoBehaviour
{
    public static CustomEventManager instance; // Singleton instance
    public UnityEvent onTimelineStart;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    
    public void TriggerTimelineStart()
    {
        onTimelineStart.Invoke();
    }
}
