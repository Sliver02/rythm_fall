using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSong : MonoBehaviour 
{
	private MusicController musicController;
	public GameObject Play;
	public GameObject MenuPanel;
	public GameObject PlayPanel;
	
	public void Restart () 
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Main");
		
	}
}
