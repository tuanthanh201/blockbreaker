using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;
    [SerializeField] float randomFactor = 0.2f;

    public bool hasStarted = false;
    Vector2 paddleToBallVector;

    Rigidbody2D myRigidBody2D;

    public void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        transform.position = new Vector2(8f, 1.3f);
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (hasStarted == false)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(xVelocity, yVelocity);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlaySound();
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        myRigidBody2D.velocity += velocityTweak;
    }

    private void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}
