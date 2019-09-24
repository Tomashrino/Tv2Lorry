using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SmoothVideoPlaylist : MonoBehaviour {
    // to smoothly cut between two videos, we need two VideoPlayers
    // make sure you create two VideoPlayers and assign them in the Inspector
  public VideoPlayer activeCam, otherCam;
  
    // edit this in the inspector, and fill it with your video clips
    public List<VideoClip> playlist = new List<VideoClip>();
  
    // internal var, keeps track of whether there's another clip cued up
  VideoClip nextClip;

  void Start () {
        // play the first video in the playlist
    PrepareNextPlaylistClip();
    SwitchCams(activeCam);

        // setup an event to automatically call SwitchCams() when we finish playing
    activeCam.loopPointReached += SwitchCams;
    otherCam.loopPointReached += SwitchCams;
  }
  
  void Update () {
        // when the current video is 0.1 seconds away from ending, prepare the next video clip on otherCam
    if ( nextClip == null && activeCam.time >= activeCam.clip.length-0.1 ) {
      PrepareNextPlaylistClip();
    }

    // FAST FORWARD CHEAT, hold down F to speed-up video
    if ( Input.GetKey(KeyCode.F) ) {
      Time.timeScale = 16f;
      activeCam.playbackSpeed = 16f;
      otherCam.playbackSpeed = 16f;
    } else {
      Time.timeScale = 1f;
      activeCam.playbackSpeed = 1f;
      otherCam.playbackSpeed = 1f;
    }

  }

    // swaps the VideoPlayer references, so activeCam is always the active VideoPlayer
  void SwitchCams (VideoPlayer thisCam) {
    activeCam = otherCam;
    otherCam = thisCam;
    activeCam.targetCameraAlpha = 1f;
        otherCam.targetCameraAlpha = 0f;
    
    Debug.Log("new clip: " + nextClip.name );
    nextClip = null;
  }

    // cues up the next video clip in the playlist
  void PrepareNextPlaylistClip () {
    nextClip = playlist[0];
    otherCam.clip = nextClip;
    otherCam.Play();
    playlist.RemoveAt(0);
  }

}