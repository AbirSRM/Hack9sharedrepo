using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aeroplanescript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public logicscript logic;

    public bool birdIsAlive = true; // Indicates if the airplane is alive
    private bool isStuck = false; // Indicates if the airplane is stuck

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicscript>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (birdIsAlive && !isStuck)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRigidbody.velocity = Vector2.up * flapStrength; // Flap action
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // For boundary collisions
    {
        if (collision.CompareTag("Boundary")) // Check for boundary collision
        {
            logic.GameOver(); // Call GameOver method from logic script
            birdIsAlive = false; // Set alive status to false
            isStuck = true; // Set stuck to true
            myRigidbody.isKinematic = true; // Stop physics movement
            transform.SetParent(collision.transform); // Stick to the boundary
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // For bird collisions
    {
        if (collision.gameObject.CompareTag("Bird")) // Collision with bird
        {
            logic.GameOver(); // Call GameOver method from logic script
            birdIsAlive = false; // Set alive status to false
            isStuck = true; // Set stuck to true
            myRigidbody.isKinematic = true; // Stop physics movement
            transform.SetParent(collision.transform); // Stick to the bird
        }
    }
}