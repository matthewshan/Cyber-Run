using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject mine;
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
            var heightObstacle = new Vector3(0, Random.Range(-heightVariance, heightVariance), 0); // Get a random height to spawn at

            GameObject newObstacle = Instantiate(obstacle); //Creates a new obstacle
            newObstacle.transform.position = transform.position + heightObstacle;
            Destroy(newObstacle, 15); //Destroy the new obstacle after 10 seconds

            // 50% change to spawn a mine in front of the obstacle
            if (Random.Range(0.0f, 1.0f) < .5)
            {
                var heightMine = new Vector3(0, Random.Range(-heightVariance / 2, heightVariance / 2), 0); // Get a random height to spawn at
                GameObject newMine = Instantiate(mine);
                newMine.transform.position = transform.position + heightObstacle + heightMine + new Vector3(-5.5f, 0, 0);
                Destroy(newMine, 15); //Destroy the new obstacle after 10 seconds
            }
            
            timer = 0; //Reset the timer to zero
        }

        timer += Time.deltaTime; //Add to the timer the amount of passed time
    }
}