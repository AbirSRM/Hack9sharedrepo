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
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicscript>();
        myRigidbody=GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    if (collision.gameObject.CompareTag("Bird"))
        {
        Debug.Log("Collided with Bird!"); // Debug statement
        logic.GameOver();
        birdIsAlive = false;
        isStuck = true;
        myRigidbody.isKinematic = true;
        transform.SetParent(collision.transform);
        }
    }
}