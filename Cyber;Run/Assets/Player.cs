using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D playerBody;

    // Health Mechanics
    public int health;
    public int invulnerableTime;
    private float invulTimer = 0;
    private double transparentIndex = 0;

    //Score Mechanics
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        playerBody = GetComponent<Rigidbody2D>(); //Get the player's body
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left Click
        {
            playerBody.velocity = Vector2.up * velocity; //Go up by the given velocity
        }

        // Check to see if we are currently invulenerable 
        if (invulTimer > 0)
        {
            invulTimer -= Time.deltaTime;

            // Transparent blink code. Basically update every .2 seconds.
            transparentIndex = (transparentIndex + Time.deltaTime) % .4;

            // Check if the invul timer is done and resets variables if so
            if (invulTimer < 0) 
            {
                invulTimer = 0;
                transparentIndex = 0;
            }

            // Updates the object's transparency
            GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, transparentIndex < .2 ? 1.0f : 0.5f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If enemy, decrement health and start the invul timer
        if (collision.gameObject.tag == "Enemy" && invulTimer == 0)
        {
            health--;
            invulTimer = invulnerableTime;
        }

        // If gap, increase the score
        if (collision.gameObject.tag == "Score" && invulTimer == 0)
        {
            score++;
        }
    }
}