using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MovementExample : MonoBehaviour
{
    public float speed = 2f;
    Vector2 position;
    Vector2 velocity;
    //int frameRate = 25;
    public float maxSpeed = 0.015f;

    public GameObject Apple;

    Rigidbody2D rb2D;

    //Vector2 gravity = new Vector2(0, -0.9f);
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        //{
        //    if (Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.A))
        //    {
        //        velocity.x += speed * Time.deltaTime;
        //    }
        //    if (Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D))
        //    {
        //        velocity.x -= speed * Time.deltaTime;
        //    }
        //    if (Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.S))
        //    {
        //        velocity.y += speed * Time.deltaTime;
        //    }
        //    if (Input.GetKey(KeyCode.S) || !Input.GetKey(KeyCode.W))
        //    {
        //        velocity.y -= speed * Time.deltaTime;
        //    }
        //}

        velocity.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        velocity.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //velocity += gravity * Time.deltaTime;
        //Debug.Log(velocity.x);

        //if (rawInput.sqrMagnitude < 1 )
        //{
        //    rawInput.Normalize();
        //}

        if (velocity.x > maxSpeed)
        {
            velocity.x = maxSpeed;
        }
        if (velocity.x < -maxSpeed)
        {
            velocity.x = -maxSpeed;
        }

        if (velocity.y > maxSpeed)
        {
            velocity.y = maxSpeed;
        }
        if (velocity.y < -maxSpeed)
        {
            velocity.y = -maxSpeed;
        }


        //if (!Input.anyKey)
        //{
        //    velocity = velocity * 0.90f;
        //}


        if (!Input.GetKey(KeyCode.D) || !(Input.GetKey(KeyCode.A)))
        {
            velocity.y = velocity.y * 0.90f;
        }
        if (!Input.GetKey(KeyCode.W) || !(Input.GetKey(KeyCode.S)))
        {
            velocity.x = velocity.x * 0.90f;
        }


        //position += velocity;
        //transform.position = position;

        rb2D.velocity = velocity;

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    Application.targetFrameRate = frameRate;
        //    frameRate += 25;
        //    frameRate %= 225;
        //    frameRate = Mathf.Clamp(frameRate, 25, 200);
        //    Debug.Log("Current Framerate: " +  frameRate);
        //}


    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.GetComponent<Apple>() != null)
    //    {
    //        points++;
    //        Destroy(gameObject);
    //    }
    //}

}
