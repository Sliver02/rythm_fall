using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SongTitle : MonoBehaviour 
{
	private SongSelector songSelector;
	public TextMeshPro title;

	void Start () {
		GameObject songSelectorObject = GameObject.FindGameObjectWithTag("SongSelector");

		if (songSelectorObject != null)
		{
			songSelector = songSelectorObject.GetComponent<SongSelector>();
		}

		if (songSelector == null)
		{
			Debug.Log("cannot find 'MusicController' script");
		}
	}
	
	void Update () 
	{
		title.text = songSelector.clips[songSelector.songIndex].name;	
	}
}
