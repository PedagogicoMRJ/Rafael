using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyHandler : MonoBehaviour
{
    bool timer;
    float wait;
    float walkTime;
    public bool hasRandomWalk;
    private int quadrant;
    public bool hasWalkAnim;
    Animator anim;
    public System.Action killed;
    Transform transform;
    Transform playerPos;
    public float enemySpeed;
    Rigidbody2D enemyRig;
    Vector2 targetDir;
    void Start()
    {
        transform = GetComponent<Transform>();
        timer = false;
        walkTime = 2f;
        if (hasWalkAnim)
            anim = GetComponentInChildren<Animator>();
        else
            anim = GetComponent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
        {
            Follow();
            enemyRig.velocity -= enemyRig.velocity / 200;
        }
        walkTime += Time.deltaTime;
        if (timer)
            wait += Time.deltaTime;
        if (hasRandomWalk)
            RandomMovement();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            this.killed.Invoke();
            anim.SetTrigger("Die");
            Destroy(gameObject, 0.5f);
            enemyRig.velocity = Vector2.zero;
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
    void RandomMovement()
    {
        if (walkTime >=0.5f)
        {
            timer = true;
            if (wait >= 5f)
            {
                wait = 0f;
                quadrant = Random.Range(0, 8);
                transform.rotation = Quaternion.identity;
                transform.Rotate(0f, 0f, quadrant * 45f);
                enemyRig.velocity = transform.up * enemySpeed;
                walkTime = 0f;
            }
        }
    }
}
