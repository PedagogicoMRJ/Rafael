using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isPlayer1;
    bool isAttack = false;
    bool isKnockback = false;
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
        if (isAttack)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                isAttack = false;
                Debug.Log("isAttack = false");
            }
        }
        if (isKnockback)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                isKnockback = false;
                Debug.Log("isKnockback = false");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!isAttack && !isKnockback)
        {
            Movement();
            Attack();
        }
    }
    void Movement()
    {
        if (isPlayer1)
            move = Input.GetAxis("Horizontal1");
        else
            move = Input.GetAxis("Horizontal2");
        rig.velocity = new Vector2(move * speed, 0f);
        anim.SetFloat("Walk", move);
    }
    public enum AttackType
{
    None,
    LP,  // Light Punch
    HP,  // Heavy Punch
    LK,  // Light Kick
    HK,  // Heavy Kick
    Block // Blocking
}

public AttackType currentAttack = AttackType.None;

void Attack()
{
    if (isPlayer1)
    {
        if (Input.GetKeyDown(KeyCode.Q)) currentAttack = AttackType.LP;
        else if (Input.GetKeyDown(KeyCode.W)) currentAttack = AttackType.HP;
        else if (Input.GetKeyDown(KeyCode.E)) currentAttack = AttackType.LK;
        else if (Input.GetKeyDown(KeyCode.R)) currentAttack = AttackType.HK;
        else if (Input.GetKeyDown(KeyCode.T)) 
        {
            currentAttack = AttackType.Block;
            block = true;
        }
        else currentAttack = AttackType.None;
    }
    else
    {
        if (Input.GetKeyDown(KeyCode.KeyPad4)) currentAttack = AttackType.LP;
        else if (Input.GetKeyDown(KeyCode.KeyPad5)) currentAttack = AttackType.HP;
        else if (Input.GetKeyDown(KeyCode.KeyPad1)) currentAttack = AttackType.LK;
        else if (Input.GetKeyDown(KeyCode.KeyPad2)) currentAttack = AttackType.HK;
        else if (Input.GetKeyDown(KeyCode.KeyPad0)) 
        {
            currentAttack = AttackType.Block;
            block = true;
        }
        else currentAttack = AttackType.None;
    }

    if (currentAttack != AttackType.None)
    {
        move = 0;
        rig.velocity = new Vector2(move * speed, 0f);
        anim.SetFloat("Walk", move);
        anim.SetTrigger(currentAttack.ToString());
        isAttack = true;
        block = false;
    }
}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        move = 0;
        rig.velocity = new Vector2(0f, 0f);
        anim.SetFloat("Walk", move);
        if (collision.gameObject.layer == 3)
        {
            anim.SetBool("Knockback", true);
            if (isPlayer1)
                rig.velocity = new Vector2(-speed * 3, 0f);
            else
                rig.velocity = new Vector2(speed * 3, 0f);
        }
    }
}
