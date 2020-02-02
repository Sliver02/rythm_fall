using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    private GameController gameController;
    private MultiplierController multiplierController;

    private void Start()
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
        
        GameObject multiplierControllerObject =  GameObject.FindGameObjectWithTag("Multiplier");

        if (multiplierControllerObject != null)
        {
            multiplierController = multiplierControllerObject.GetComponent<MultiplierController>();
        }

        if (multiplierController == null)
        {
            Debug.Log("cannot find 'MultiplierController' script");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Boundry") || other.CompareTag("Enemy"))
        {
            return;
        }

        if (other.CompareTag ("Player"))
        {
            if (GameController.win == true)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                if (multiplierController.lifes < 0)
                {
                    gameController.GameOver();
                    Destroy(GameObject.FindWithTag("Player"));
                }
                else
                {
                    multiplierController.lifeDown();
                    //MoverByAudioBands.SpeedAnimation();
                    Destroy(transform.parent.gameObject);
                }
            }
        }
    }
}