using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    public AudioSource audioball;
    void Start()
    {
        startPosition = transform.position;
        Launch();
    }
    
    private void Launch()
    {
        
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float y = Random.Range(0,2) == 0 ? -1 : 1;
        
    rb.velocity = new Vector2(speed * x, speed * y);
    }
    public void Reset()

    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioball.Play();
    }
}


