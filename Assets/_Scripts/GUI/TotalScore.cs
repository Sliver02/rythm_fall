using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour 
{
    public TextMeshPro totalScoreText;
    public ScoreController scoreController;

    private void Update()
    {
        if (GameController.gameOver == true || GameController.win == true)
        {
            totalScoreText.text = "SCORE\n" + scoreController.scoreValue + "p";
        }
    }
}
