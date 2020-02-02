using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverByAudioBands : MonoBehaviour 
{
    private GameController gameController;
    private SelectBand selectBand;

    private int bandSelected;

    private bool controller;

    public float velocityMultiplier;
    public float startVelocity;
    public static float velocity;
    public static float increseSpeed;

    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("cannot find 'GameController' script");
        }
        
        selectBand = GetComponent<SelectBand>();
        bandSelected = selectBand.bandSelected;

        velocity = startVelocity;
    }
	
	void FixedUpdate ()
    {
        transform.position += new Vector3(0, ((MusicController.audioBandBuffer[bandSelected] * velocityMultiplier) + gameController.fixedVelocity), 0);
    }
}
