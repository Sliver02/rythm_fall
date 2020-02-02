using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexButton : MonoBehaviour
{
	private SongSelector songSelector;
	public bool side;

	private void Start()
	{
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

	public void ChangeIndex()
	{
		if (side)
		{
			songSelector.songIndex++;
		}
		else
		{
			songSelector.songIndex--;
		}
        
         
		if(songSelector.songIndex > songSelector.clips.Length - 1)
		{
			songSelector.songIndex = 0;
		}
		else if(songSelector.songIndex < 0)
		{
			songSelector.songIndex = songSelector.clips.Length - 1;
		}
	}
}