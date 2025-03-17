using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyHandler : MonoBehaviour
{
    public System.Action killed;
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
        if (collision.tag == "Bullet")
        {
            this.killed.Invoke();
            this.gameObject.SetActive(false);
        }
        if (collision.tag == "Player")
        {
            Debug.Log("Get Better!");
        }
    }
}
