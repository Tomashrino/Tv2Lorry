using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    //[SerializeField] private EventBroadcaster broadcaster;
    [SerializeField] private UnityEvent OnTriggered;
    private bool isSubbed = false;

    private void Start()
    {
        if (!isSubbed)
        {
            EventBroadcaster.Instance.trigger += OnCallTrigger;
            isSubbed = true;
        }
    }

    private void OnEnable()
    {
        if (EventBroadcaster.Instance != null && !isSubbed)
        {
            isSubbed = true;
            EventBroadcaster.Instance.trigger += OnCallTrigger;
        }
    }

    private void OnDisable()
    {
        EventBroadcaster.Instance.trigger -= OnCallTrigger;
        isSubbed = false;
    }

    private void OnCallTrigger()
    {
        Debug.Log("OnCallTrigger Called!");
        OnTriggered?.Invoke();
    }
}
