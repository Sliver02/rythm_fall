using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Completition : MonoBehaviour 
{
	public TextMeshPro totalScoreText;
	private bool check = false;
	private int percentageReached = 0;

	private void Update()
	{
		if ((GameController.gameOver == true || GameController.win == true) && check == false)
		{
			if (MusicController.songPosition + 1 >= MusicController.songLength)
			{
				percentageReached = 100;
			}
			else
			{
				percentageReached = (int)MusicController.songPercentage;
			}

			totalScoreText.text = "COMPLETED\n" + percentageReached + "%";
			check = true;
		}
	}
}
