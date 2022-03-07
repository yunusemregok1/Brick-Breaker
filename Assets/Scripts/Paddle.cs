using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D paddleRb;
    public Vector2 paddleDirection;
    public float paddleSpeed = 50;
    public float maxBounceAngle = 75f;

    private void Awake()
    {
        paddleRb = GetComponent<Rigidbody2D>();
    }
    public void ResetPaddle()
    {
        transform.position = new Vector2(0f, transform.position.y);
        paddleRb.velocity = Vector2.zero;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            paddleDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            paddleDirection = Vector2.right;
        }
        else
        {
            paddleDirection = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (paddleDirection != Vector2.zero)
        {
            paddleRb.AddForce(paddleDirection * paddleSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball!=null)
        {
            Vector2 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.ballRb.velocity);
            float bounceAngle = (offset / width) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.ballRb.velocity = rotation * Vector2.up * ball.ballRb.velocity.magnitude;
        }

    }

}
