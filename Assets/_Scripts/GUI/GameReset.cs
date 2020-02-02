using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
	private MusicController musicController;
	
	public void Reset() 
	{
		Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
}