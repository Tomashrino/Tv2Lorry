using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class EventBroadcaster : MonoBehaviour
{
    public static EventBroadcaster Instance;
    public VideoPlayer videoPlayer;

    // Acts as a delegate (used to broadcast the occurence of an event)
    public UnityAction trigger;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogWarning("Be aware!!! Another Instance already exists!");
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (videoPlayer != null)
        {
            Debug.Log("videoPlayer.frame: " + (ulong)videoPlayer.frame);
            Debug.Log("videoPlayer.frameCount: " + videoPlayer.frameCount);
            if ((ulong)videoPlayer.frame == videoPlayer.frameCount - 1)
            {
                Debug.Log("Video Ended");
                trigger?.Invoke();
                videoPlayer.enabled = false;
                Debug.Log("Same Frame");
            }

        }

    }

    

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Debug.Log("OnTriggerEnter Called!");
    //        trigger?.Invoke();
    //    }
    //}
}
