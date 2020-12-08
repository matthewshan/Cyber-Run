using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public int patrolThreshold; // How long to go up or down
    public int leftSpeed; // This should be the same as the velocity of obstacles

    private bool isUp = true;
    private float patrolTimer = 0;
    private float upDownSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Set up/down speed to a random interval
        upDownSpeed = Random.Range(2.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        var yMovement = isUp ? Vector3.up : Vector3.down;
        transform.position += ((yMovement * upDownSpeed) + (Vector3.left * leftSpeed)) * Time.deltaTime;

        patrolTimer += Time.deltaTime;

        // Change directions if past threshold
        if (patrolTimer > patrolThreshold)
        {
            isUp = !isUp;
            patrolTimer = 0;
        }
    }
}
