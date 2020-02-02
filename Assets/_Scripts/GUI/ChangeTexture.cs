using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTexture : MonoBehaviour 
{
	public Sprite PlaySprite;
	public Sprite PauseSprite;
	public Button but;
	
	public void ChangeImage(){
		if (but.image.sprite == PlaySprite)
			but.image.sprite = PauseSprite;
		else {
			but.image.sprite = PlaySprite;
		}
	}
}
