using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageVideoDisplay : MonoBehaviour
{

	GameObject video;
	//video.SetActive(false); // false to hide, true to show
    //video.GetComponent<Renderer>().enabled = false;
    public void VideoDisplayOn()
	{
		video.GetComponent<Renderer>().enabled = true;
	}

	public void VideoDisplayOff()
	{
        video.GetComponent<Renderer>().enabled = false;
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
