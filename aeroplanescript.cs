using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aeroplanescript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public logicscript logic;
    public bool birdIsAlive = true;
    private bool isStuck = false;

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
                myRigidbody.velocity = Vector2.up * flapStrength;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            logic.GameOver(); // Call GameOver method
            birdIsAlive = false;
            isStuck = true;
            myRigidbody.isKinematic = true;
            transform.SetParent(collision.transform);
        }
    }
}