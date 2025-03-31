using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyHandler : MonoBehaviour
{
    public bool hasWalkAnim;
    Animator anim;
    public System.Action killed;
    Transform playerPos;
    public float enemySpeed;
    Rigidbody2D enemyRig;
    Vector2 targetDir;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
;       playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyRig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame;
    void Update()
    {
        targetDir = playerPos.position - this.transform.position;
        targetDir.Normalize();
        if (hasWalkAnim)
            Walk();
        else
            Follow();
        enemyRig.velocity -= enemyRig.velocity / 200;
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
    void Follow()
    {
        if (enemyRig.velocity.magnitude <= 5f)
        {
            enemyRig.AddForce(targetDir * enemySpeed);
        }
    }
    void Walk()
    {
        anim.SetFloat("Horizontal", targetDir.x);
        anim.SetFloat("Vertical", targetDir.y);
        anim.SetFloat("Magnitude", targetDir.magnitude);
    }
}
