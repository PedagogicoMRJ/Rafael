using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    Transform playerPos;
    public float enemySpeed;
    Rigidbody2D enemyRig;
    Vector2 targetDir;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyRig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame;
    void Update()
    {
        targetDir = playerPos.position - transform.position;
        targetDir.Normalize();
        enemyRig.velocity = targetDir * enemySpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("U Died");
            //Debug.Log("U got f*cked");
        }
    }
}
