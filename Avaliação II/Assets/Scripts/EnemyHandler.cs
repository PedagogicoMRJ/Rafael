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
    float powerUp;
    public System.Action killed;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemyRig = this.GetComponent<Rigidbody2D>();
        if (isEnemy1)
            playerPos = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>();
        else
            playerPos = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();
        transform = GetComponent<Transform>();
        //StartCoroutine(DisableCollision());
    }

    // Update is called once per frame
    void Update()
    {
        targetDir = playerPos.position - this.transform.position;
        targetDir += new Vector2(Random.Range(-1.0f + powerUp / 2, 1.0f - powerUp / 2), Random.Range(-1.0f + powerUp / 2, 1.0f - powerUp / 2));
        targetDir.Normalize();
        Follow();
        enemyRig.velocity -= enemyRig.velocity / 200f;
    }
    void Follow()
    {
        if (enemyRig.velocity.magnitude <= 5f - powerUp * 1.5)
        {
            enemyRig.AddForce(targetDir * enemySpeed);
        }
    }
    public void SetLevel(int lv)
    {
        powerUp = (lv - 1) / 9;
    }
    private void OnTriggerEnter(Collider2D collison)
    {
        if (isEnemy1)
        {
            if (collison.tag == "Bullet2")
            {
                anim.SetTrigger("Die");
                Destroy(gameObject, 0.8f);
                this.killed.Invoke();
            }
            if (collison.tag == "Player1")
            {
                anim.SetTrigger("Die");
                Destroy(gameObject, 0.8f);
            }
        }
        else
        {
            if (collison.tag == "Bullet1")
            {
                anim.SetTrigger("Die");
                Destroy(gameObject, 0.8f);
                this.killed.Invoke();
            }
            if (collison.tag == "Player2")
            {
                anim.SetTrigger("Die");
                Destroy(gameObject, 0.8f);
            }
        }
    }
    IEnumerator DisableCollision()
    {
        if (isEnemy1)
            Physics.IgnoreLayerCollision(11, 6);
        else
            Physics.IgnoreLayerCollision(12, 6);
        yield return new WaitForSeconds(1);
        if (isEnemy1)
            Physics.IgnoreLayerCollision(11, 6, false);
        else
            Physics.IgnoreLayerCollision(12, 6, false);
    }
}
