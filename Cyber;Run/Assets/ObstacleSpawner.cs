using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnInterval;    
    public float heightVariance;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnInterval; // Initialize  the timer
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > spawnInterval) // Check if the timer has reached the specified spawnInterval
        {
            GameObject newObstacle = Instantiate(obstacle); //Creates a new obstacle
            newObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-heightVariance, heightVariance), 0); //Sets the position a random height and the transformat position
            Destroy(newObstacle, 10); //Destroy the new obstacle after 10 seconds
            timer = 0; //Reset the timer to zero
        }

        timer += Time.deltaTime; //Add to the timer the amount of passed time
    }
}