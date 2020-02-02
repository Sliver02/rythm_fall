using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	private Rigidbody rb;
	private Vector3 angle;

	public float fixedTumble;
	public float tumbleMultiplier;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();

		angle = Random.insideUnitSphere;

		//var asdasd = tumble * MusicController.amplitudeBuffer;
		//rb.angularVelocity = Random.insideUnitSphere * tumble;
	}

	private void Update()
	{
		rb.angularVelocity = angle * ((MusicController.amplitudeBuffer * tumbleMultiplier) + fixedTumble);
	}
}