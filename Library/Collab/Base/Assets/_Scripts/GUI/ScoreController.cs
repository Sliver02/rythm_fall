using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
	public TextMeshPro scoreText;
	public int scoreValue = 0;
	
	public float pointsFrequency;
	public float pointsDivider;
	private int songPoints;
	public int bonusPoints;

	private void Update()
	{
		if (GameController.gameOver == false)
		{
			SongScore();
		}
		
		scoreText.text = "Score \n" + scoreValue;
	}

	private void SongScore()
	{
		songPoints = (int)MusicController.songPosition;

		scoreValue = songPoints + bonusPoints;
	}
}