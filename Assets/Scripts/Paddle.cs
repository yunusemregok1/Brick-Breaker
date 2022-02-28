using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D PaddleRb;
    public Vector2 PaddleDirection;
    public float PaddleSpeed = 50;

    private void Awake()
    {
        PaddleRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            PaddleDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            PaddleDirection = Vector2.right;
        }
        else
        {
            PaddleDirection = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (PaddleDirection != Vector2.zero)
        {
            PaddleRb.AddForce(PaddleDirection * PaddleSpeed);
        }
    }
}
