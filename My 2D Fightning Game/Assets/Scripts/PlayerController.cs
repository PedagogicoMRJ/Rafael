using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isAttack = false;
    string attack = "None";
    public float speed;
    private Animator anim;
    private Rigidbody2D rig;
    bool block = false;
    float move;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (isAttack = true)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                isAttack = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isAttack == false)
        {
            Movement();
            Attack();
        }
    }
    void Movement()
    {
        move = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(move * speed, 0f);
        anim.SetFloat("Walk", move);
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        attack = "LP";
        else if (Input.GetKeyDown(KeyCode.W))
        attack = "HP";
        else if (Input.GetKeyDown(KeyCode.E))
        attack = "LK";
        else if (Input.GetKeyDown(KeyCode.R))
        attack = "HK";
        else if (Input.GetKeyDown(KeyCode.T))
        {
            attack = "Block";
            block = true;
        }
        else
        {
            attack = "None";
            block = false;
        }
        
        if (attack != "None")
        {
            move = 0;
            rig.velocity = new Vector2(move*speed, 0f);
            anim.SetFloat("Walk", move);
            anim.SetTrigger(attack);
            isAttack = true;
        }
    }
}
