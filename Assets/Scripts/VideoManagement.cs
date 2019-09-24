using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManagement : MonoBehaviour
{
	[SerializeField] private VideoPlayer vp;
	//[SerializeField] private VideoPlayer vp2;
	//[SerializeField] private VideoPlayer vp3;
	public Button playBtn;
	public Sprite playIcon;
	public Sprite pauseIcon;
	//public Image image;


	// Start is called before the first frame update
	private void Start()
	{
		playBtn.onClick.AddListener(ToggleVideoPlayback);
	}

	public void ToggleVideoPlayback()
	{
		if (vp.isPlaying)
		{
			vp.Pause();
			// playBtn.GetComponentInChildren<Image>().sprite = playIcon;
			playBtn.GetComponentInChildren<Image>().sprite = playIcon;
		}
		else
		{
			vp.Play();
			playBtn.GetComponentInChildren<Image>().sprite = pauseIcon;
		}
	}
	// // Start is called before the first frame update
	// void Start()
	// {

	// }

	// // Update is called once per frame
	// void Update()
	// {

	// }
}
