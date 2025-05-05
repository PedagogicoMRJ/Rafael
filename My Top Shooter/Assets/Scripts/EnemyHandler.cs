using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyHandler : MonoBehaviour
{
    public bool IsZombie;
    Bullet bulletParameters;
    int life;
    bool timer;
    float fireCooldown;
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
        bulletParameters = GetComponentInChildren<Bullet>();
        transform = GetComponent<Transform>();
        timer = false;
        walkTime = 10f;
        wait = 10f;
        if (hasWalkAnim)
            anim = GetComponentInChildren<Animator>();
        else
            anim = GetComponent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyRig = this.GetComponent<Rigidbody2D>();
        if (!hasWalkAnim)
            life = 2;
        else if (hasRandomWalk)
            life = 1;
        else
            life = 3;
    }

    // Update is called once per frame;
    void Update()
    {
        targetDir = playerPos.position - this.transform.position;
        targetDir.Normalize();
        if (hasWalkAnim)
            Walk();
        else if (!IsZombie)
        {
            Follow();
            enemyRig.velocity -= enemyRig.velocity / 200;
        }
        walkTime += Time.deltaTime;
        if (timer)
            wait += Time.deltaTime;
        if (hasRandomWalk)
        { RandomMovement(); Fire(); }
        fireCooldown += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            life -= 1;
            if (life <= 0)
            {
                this.killed.Invoke();
                anim.SetTrigger("Die");
                Destroy(gameObject);
                enemyRig.velocity = Vector2.zero;
            }
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
        if (walkTime >= 5f)
        {
            timer = true;
            enemyRig.velocity = transform.up * enemySpeed;
            if (wait >= 0.5f)
            {
                wait = 0f;
                quadrant = Random.Range(0, 8);
                transform.rotation = Quaternion.identity;
                transform.Rotate(0f, 0f, quadrant * 45f);
                walkTime = 0f;
                timer = false;
            }
        }
    }
    void Fire()
    {
        if (fireCooldown >= 5f)
        {
            Vector2 bulletAim = targetDir + new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            bulletParameters.fireBullet(bulletAim);
            fireCooldown = 0f;
        }
    }
}
