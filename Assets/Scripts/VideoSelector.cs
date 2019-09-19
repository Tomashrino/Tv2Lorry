using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSelector : MonoBehaviour
{

	public VideoPlayer videoPlayer;
	public VideoClip NewClip;
	void OnEnable()
	{
		videoPlayer.loopPointReached += loopPointReached;
	}

	void OnDisable()
	{
		videoPlayer.loopPointReached -= loopPointReached;
	}

	void loopPointReached(VideoPlayer v)

	{
		videoPlayer.clip = NewClip;
		videoPlayer.Play();
	}

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}



//using UnityEngine;
//using UnityEngine.Video;

//public class selectAndPlay_video : MonoBehaviour
//{

	
//}