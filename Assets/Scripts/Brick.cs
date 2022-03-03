using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] states;
    public int health { get; private set; }
    public bool unbreaklable;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        if (!unbreaklable)
        {
            health = states.Length;
            spriteRenderer.sprite = states[health - 1];
        }
    }
    private void Hit()
    {
        if (unbreaklable)
        {
            return;
        }

        health--;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            spriteRenderer.sprite = states[health - 1];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Hit();
        }
    }

}
