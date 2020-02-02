using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour
{
	private static FloatingText popupText;
	private static GameObject canvas;
	private static GameObject player;

	public static void Initialize()
	{
		canvas = GameObject.Find("GUI");

		player = GameObject.FindWithTag("Player");
		
		if(!popupText)
			popupText = Resources.Load<FloatingText>("Prefab/PopupText");
	}
	
	public static void CreateBonusPointsText(string text, Transform location)
	{
		FloatingText instance = Instantiate(popupText);


		var spawnPosition = player.transform.position;
		var spawnRotation = Quaternion.identity;
		
		instance.transform.transform.SetParent(canvas.transform, false);
		instance.transform.position = spawnPosition;
		instance.SetText(text);
	}
}