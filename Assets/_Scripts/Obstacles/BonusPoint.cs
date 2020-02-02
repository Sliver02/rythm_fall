using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BonusPoint : MonoBehaviour
{
    private ScoreController scoreScript;
    public MultiplierController multiplierController;
    
    public int points;

    private void Start()
    {
        GameObject scoreScriptObject = GameObject.FindGameObjectWithTag("CurrentScore");

        if (scoreScriptObject != null)
        {
            scoreScript = scoreScriptObject.GetComponent<ScoreController>();
        }

        if (scoreScript == null)
        {
            Debug.Log("cannot find 'CurrentScore' script");
        }
        
        GameObject multiplierControllerObject = GameObject.FindGameObjectWithTag("Multiplier");

        if (multiplierControllerObject != null)
        {
            multiplierController = multiplierControllerObject.GetComponent<MultiplierController>();
        }

        if (multiplierController == null)
        {
            Debug.Log("cannot find 'multiplierController' script");
        }
        
        FloatingTextController.Initialize();

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Boundry") || other.CompareTag("Enemy"))
        {
            return;
        }
        
        if (other.CompareTag ("Player"))
        {
            points *= multiplierController.multiplier;
            
            FloatingTextController.CreateBonusPointsText("+" + points.ToString(), transform);
            scoreScript.bonusPoints += points;
            
            Destroy(gameObject);
        }
        
    }
}
