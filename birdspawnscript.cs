using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipespawnscript : MonoBehaviour
{
   public GameObject birdstacle;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 15;
    // Start is called before the first frame update
    void Start()
    {
      spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(birdstacle, new Vector2(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);

    }
}
