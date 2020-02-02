using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierController : MonoBehaviour
{
	public GameController gameController;
	public PlayerController playerController;
	public TextMeshPro multiText;
	public GameObject[] lifesObj;
	public int[] multiCounter;

	public int lifes = -1;
	private float lifeTime;
	public float resetTime;
	public int multiplier;

	void Update()
	{ 	
		lifeTime -= Time.deltaTime;
		
		if (lifeTime < 0 && lifes > -1)
		{
			lifeTime = resetTime;
			lifeDown();
		}

		if (lifes < 0)
		{
			multiText.text = "";
			multiplier = 1;
		}
		else
		{
			multiplier = multiCounter[lifes];
			multiText.text = "x" + multiplier;
		}
	}

	public void lifeUp ()
	{
		lifeTime = resetTime;

		if (lifes < lifesObj.Length - 1)
		{
			lifes++;
			gameController.IncreseSpeed();
			lifesObj[lifes].SetActive(true);
		}
	}

	public void lifeDown()
	{
		lifesObj[lifes].SetActive(false);
		gameController.DecreseSpeed();
		lifes--;
	}
}
