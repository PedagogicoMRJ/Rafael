using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    public bool isPlayerLeft;
    public float speed;
    public Rigidbody2D rb;
    public float movement;
    public Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }
    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
    void Update()
    {
        if(isPlayerLeft)
        {
            movement = Input.GetAxisRaw("Vertical1");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }
        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }
}
