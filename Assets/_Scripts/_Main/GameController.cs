using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[System.Serializable]
public class SpawnWait
{
    public float start;
    public float basic;
    public float special;
    public float wave;
    public float powerUp, powerUp2;
}

public class GameController : MonoBehaviour
{
    public GameObject basicObstacle;
    public GameObject specialObstacle;
    public GameObject powerUp;
    public GameObject scoreMenu;
    public GameObject playMenu;

    public Vector3 spawnValue;
    static public Vector3 screenSize;
    static public Vector3 screenPosition;

    static public float screenLeft, screenRight;
    
    public TextMeshPro scoreText;
    public static bool gameOver;
    public static bool win;
    
    private float speedBoost; 
    private int totalSpeedBoosts;
    private int songTotalLength;
    private int obstacleCount;
    public int initialObstacle;
    public float fixedVelocity;
    public float increseSpeed;
    
    public SpawnWait spawnWait;
    private PlayerController playerController;
    private MusicController musicController;
    
    public float[] waveSpawns;
    public bool[] waveSpawnsChecks;
    public int[] obstacleIncrement;
    
    private void Start()
    {
        GameObject playerControllerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerControllerObject != null)
        {
            playerController = playerControllerObject.GetComponent<PlayerController>();
        }

        if (playerController == null)
        {
            Debug.Log("cannot find 'PlayerController' script");
        }

        screenPosition = new Vector3 (Screen.width, Screen.height, 0);
        screenSize = Camera.main.ScreenToWorldPoint(screenPosition);

        screenLeft = screenSize.x * -1;
        screenRight = screenSize.x;
        print(screenLeft);
        print(screenRight);
        
        gameOver = false;
        win = false;
        scoreText.text = "";

        obstacleCount = initialObstacle;
        speedBoost = spawnWait.powerUp;

        StartCoroutine(SpawnController());
        
    }

    private void Update()
    {
        if ( MusicController.songPosition + 1 >= MusicController.songLength)
        {
            if (gameOver == false)
            {
                Win();
            }
            else
            {
                SceneManager.LoadScene("Main");
            }
        }
        
        SpeedBoostSpawn();
        BasicObstacleIncrement();
    }
    
    public void GameOver()
    {
        scoreText.text = "GAME OVER";
        gameOver = true;
        playMenu.SetActive(false);
        scoreMenu.SetActive(true);
    }

    private void Win()
    {
        scoreText.text = "YOU WON!";
        win = true;
        playMenu.SetActive(false);
        gameObject.SetActive(false);
        scoreMenu.SetActive(true);
    }

    
    // SPAWN CONTROLLER
    private IEnumerator SpawnController()
    {
        yield return new WaitForSeconds(spawnWait.start);

        while (true)
        {
            for (var i = 0; i < obstacleCount; i++)
            {
                BasicObstacle();
            
                yield return new WaitForSeconds(spawnWait.basic);
            }

            if (MusicController.songPercentage > waveSpawns[1])
            {
                SpecialObstacle();
                yield return new WaitForSeconds(spawnWait.special);
            }
            
            yield return new WaitForSeconds(spawnWait.wave);
        }
    }
    
    // BASIC OBSTACLE
    private void BasicObstacle()
    {
        var spawnPosition = new Vector3(Random.Range(screenLeft, screenRight), spawnValue.y, spawnValue.z);
        var spawnRotation = Quaternion.identity;

        var ObjInstaciated = Instantiate(basicObstacle, spawnPosition, spawnRotation);

        ObjInstaciated.transform.localScale = Vector3.one;
    }
    
    private void BasicObstacleIncrement()
    {
        for (var i = 0; i < waveSpawns.Length; i++)
        {
            if (MusicController.songPercentage > waveSpawns[i] && waveSpawnsChecks[i] == false)
            {
                obstacleCount += obstacleIncrement[i];
                waveSpawnsChecks[i] = true;
            }
        }
    }

    // SPECIAL OBSTACLE
    private void SpecialObstacle()
    {
        float x = 0.0f;
        
        var spawnPosition = new Vector3(x, spawnValue.y, spawnValue.z);
        var spawnRotation = Quaternion.identity;

        var ObjInstaciated = Instantiate(specialObstacle, spawnPosition, spawnRotation);

        ObjInstaciated.transform.localScale = Vector3.one;
    }
    
    // SPEED BOOST
    public void SpeedBoost()
    {
        var spawnPosition = new Vector3(Random.Range(screenLeft, screenRight), spawnValue.y, spawnValue.z);
        var spawnRotation = Quaternion.identity;

        var ObjInstaciated = Instantiate(powerUp, spawnPosition, spawnRotation);

        ObjInstaciated.transform.localScale = Vector3.one;
    }

    private void SpeedBoostSpawn()
    {
        speedBoost -= Time.deltaTime;

        if (speedBoost < 0 && gameOver == false)
        {
            speedBoost = spawnWait.powerUp;

            SpeedBoost();
        }
    }

    public void SpeedBoostRespawn()
    {
        speedBoost = spawnWait.powerUp2;
    }
    
    public void IncreseSpeed()
    {
        fixedVelocity += increseSpeed;
    }
    
    public void DecreseSpeed()
    {
        fixedVelocity -= increseSpeed;
    }
}