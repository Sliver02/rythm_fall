using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class Boundry
{
    public float xMin, xMax;
    public float yMin, yMax;
}

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public Boundry boundry;

    public float forwardSpeed, backwardSpeed, xSpeed;
    public float accelerationRate, decelerationRate;

    private bool startAnimation;

    private void Start()
    {
        startAnimation = true;
        forwardSpeed = -forwardSpeed;
    }
    
    private void FixedUpdate()
    {
        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverTouchHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");

        rb = GetComponent<Rigidbody>();

        Vector3 movement = new Vector3(moverTouchHorizontal, 0.0f, 0.0f);
        
        
        rb.velocity = movement * xSpeed;

        // Animazione iniziale
        if (startAnimation == true && transform.position.y >= boundry.yMin)
        {
            rb.velocity += transform.up * forwardSpeed;
        }
        else
        {
            startAnimation = false;
        }

        // Animazione vittoria
        if (GameController.win == true)
        {
            
            rb.velocity += transform.up * forwardSpeed;
        }

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, GameController.screenLeft, GameController.screenRight),
                                   rb.position.y,
                                   0.0f);
    }

    public void GoDown()
    {
        boundry.yMin -= accelerationRate;
    }

    public void GoUp()
    {
        boundry.yMin += decelerationRate;
    }
}