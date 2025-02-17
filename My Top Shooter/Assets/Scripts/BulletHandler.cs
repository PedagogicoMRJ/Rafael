using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    Animator bulletAnim;
    Rigidbody2D bulletRig;
    void Start()
    {
        bulletRig = GetComponent<Rigidbody2D>();
        bulletAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            bulletRig.velocity = Vector2.zero;
            bulletAnim.SetTrigger("Impact");
            Destroy(gameObject, 0.12f);
        }
    }
}
