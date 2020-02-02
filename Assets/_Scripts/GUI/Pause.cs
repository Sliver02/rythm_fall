using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

	public MusicController musicController;
	public GameObject pausePanel;
	public bool paused;
	
	void Start ()
	{
		paused = false;
	}
	
	public void Paused()
	{
		paused = !paused;
		
		if (paused)
		{
			Time.timeScale = 0;
			musicController.song.Pause();
			pausePanel.SetActive(true);
		}
		else if (!paused)
		{
			Time.timeScale = 1;
			musicController.song.UnPause();
			pausePanel.SetActive(false);
		}
	}
}
