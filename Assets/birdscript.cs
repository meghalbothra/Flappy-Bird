using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdscript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength = 1000f; // Adjust this value to change the flap strength
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float gameSpeed = 10.0f; // Adjust this value to change the game speed

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        Time.timeScale = gameSpeed; // Set the initial game speed
    }

    void Update()
    {
        // Check for input on both PC and mobile devices
        if ((Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) && birdIsAlive)
        {
            // PC input or touch input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRigidBody.velocity = Vector2.up * flapStrength;
            }
            else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                myRigidBody.velocity = Vector2.up * flapStrength;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
