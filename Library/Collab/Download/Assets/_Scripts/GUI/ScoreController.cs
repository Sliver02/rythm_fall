using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
	public TextMeshPro scoreText;
	public MultiplierController multiplierController;
	public int scoreValue = 0;

	private int songPoints;
	public int bonusPoints;
	
	private float lifeTime;
	public float resetTime;

	private void Update()
	{
		if (GameController.gameOver == false)
		{
			SongScore();
		}
		
		scoreText.text = "Score\n" + scoreValue + "p";
	}

	private void SongScore()
	{
		lifeTime -= Time.deltaTime;
		
		if (lifeTime < 0)
		{
			lifeTime = resetTime;
			
			songPoints += 1 * multiplierController.multiplier;
			
			//songPoints = (int) MusicController.songPosition * multiplierController.multiplier;

			scoreValue = songPoints + bonusPoints;
		}
	}
} 