using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    public bool isEnemy;
    Animator bulletAnim;
    Rigidbody2D bulletRig;
    void Start()
    {
        bulletRig = GetComponent<Rigidbody2D>();
        bulletAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEnemy)
        {
            if (collision.tag != "Enemy")
            {
                bulletRig.velocity = Vector2.zero;
                bulletAnim.SetTrigger("Impact");
                Destroy(gameObject, 0.30f);
            }
        }
        else
        {
            if (collision.tag != "Player")
            {
                bulletRig.velocity = Vector2.zero;
                bulletAnim.SetTrigger("Impact");
                Destroy(gameObject, 0.30f);
            }
        }
    }
}
