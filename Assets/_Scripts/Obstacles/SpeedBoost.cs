using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private Renderer[] rend;
    
    private GameController gameController;
    private MultiplierController multiplierController;
    
    private void Update()
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
        
        GameObject multiplierControllerObject = GameObject.FindGameObjectWithTag("Multiplier");

        if (multiplierControllerObject != null)
        {
            multiplierController = multiplierControllerObject.GetComponent<MultiplierController>();
        }

        if (multiplierController == null)
        {
            Debug.Log("cannot find 'GameController' script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundry") || other.CompareTag("Enemy"))  
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            gameController.SpeedBoostRespawn();
            multiplierController.lifeUp();
            Destroy(gameObject);
        }
        
        
    }
}