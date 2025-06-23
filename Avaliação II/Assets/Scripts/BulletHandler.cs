using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    public bool isPlayer1;
    Animator bulletAnim;
    Rigidbody2D bulletRig;
    void Start()
    {
        bulletRig = GetComponent<Rigidbody2D>();
        bulletAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Collision");
        if (isPlayer1)
        {
            if (collision.tag != "Player" || collision.tag != "Enemy2")
            {
                bulletRig.velocity = Vector2.zero;
                bulletAnim.SetTrigger("Impact");
                Destroy(gameObject, 0.33f);
            }
        }
        else
        {
            if (collision.tag != "Player" || collision.tag != "Enemy1")
            {
                bulletRig.velocity = Vector2.zero;
                bulletAnim.SetTrigger("Impact");
                Destroy(gameObject, 0.33f);
            }
        }
    }
}