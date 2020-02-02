using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class MoverByAmplitude : MonoBehaviour
{
    private GameController gameController;
    public float startVelocity, velocityMultiplier, maxVelocity;
    private float fixedVelocity;

    public float increseSpeed;

    void Start()
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

        fixedVelocity = startVelocity;
    }

    public void FixedUpdate()
    {
        transform.position += new Vector3(0, ((MusicController.amplitudeBuffer * velocityMultiplier) + gameController.fixedVelocity), 0);
    }

    
}
