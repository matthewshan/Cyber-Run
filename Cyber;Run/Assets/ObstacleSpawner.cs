using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float interval;
    public GameObject obstacle;
    public float height;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = interval;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > interval)
        {
            GameObject newObstacle = Instantiate(obstacle);
            newObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newObstacle, 10);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
