using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    Rigidbody2D enemyRig;
    Vector2 targetDir;
    Transform playerPos;
    Transform transform;
    public float enemySpeed;
    public bool isEnemy1;
    // Start is called before the first frame update
    void Start()
    {
        enemyRig = this.GetComponent<Rigidbody2D>();
        if (isEnemy1)
            playerPos = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>();
        else
            playerPos = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        targetDir = playerPos.position - this.transform.position;
        targetDir.Normalize();
        Follow();
        enemyRig.velocity -= enemyRig.velocity / 1000f;
    }
    void Follow()
    {
        if (enemyRig.velocity.magnitude <= 5f)
        {
            enemyRig.AddForce(targetDir * enemySpeed);
        }
    }
}
