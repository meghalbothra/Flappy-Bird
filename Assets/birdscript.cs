using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdscript : MonoBehaviour
{
    // Start is called before the first frame update

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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive) 
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
} 
