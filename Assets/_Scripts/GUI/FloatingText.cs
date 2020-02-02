using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
	public Animator animator;
	public TextMeshPro bonusText;
	
	public float clipLength;
	
	void Start ()
	{
		AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);

		clipLength = clipInfo[0].clip.length;
		
		Destroy(gameObject, clipLength);
	}

	public void SetText(string text)
	{
		bonusText.text = text;
	}
}