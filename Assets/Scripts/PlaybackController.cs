using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PlaybackController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private Button playBtn;
    private Image iconImage;

    private Sprite playIcon;
    private Sprite pauseIcon;

    // Start is called before the first frame update
    void Start()
    {
        playBtn.onClick.AddListener(ToggleVideoPlayback);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleVideoPlayback()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            playBtn.GetComponentInChildren<Text>().text = "Play";
        }
        else
        {
            videoPlayer.Play();
            playBtn.GetComponentInChildren<Text>().text = "Pause";
        }
    }
}
