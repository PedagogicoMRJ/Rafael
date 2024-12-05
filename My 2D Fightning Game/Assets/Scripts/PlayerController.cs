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
    int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;
    int attackDamage; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rig = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void FixedUpdate()
    {
        if (isAttack)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                isAttack = false;
                block = false;
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
             if (Input.GetKeyDown(KeyCode.Q)) { currentAttack = AttackType.LP; attackDamage = 05; }
        else if (Input.GetKeyDown(KeyCode.W)) { currentAttack = AttackType.HP; attackDamage = 15; }
        else if (Input.GetKeyDown(KeyCode.E)) { currentAttack = AttackType.LK; attackDamage = 10; }
        else if (Input.GetKeyDown(KeyCode.R)) { currentAttack = AttackType.HK; attackDamage = 30; }
        else if (Input.GetKeyDown(KeyCode.T)) { currentAttack = AttackType.Block; block = true; }
        else currentAttack = AttackType.None;
    }
    else
    {
             if (Input.GetKeyDown(KeyCode.Keypad4)) { currentAttack = AttackType.LP; attackDamage = 04; }
        else if (Input.GetKeyDown(KeyCode.Keypad5)) { currentAttack = AttackType.HP; attackDamage = 12; }
        else if (Input.GetKeyDown(KeyCode.Keypad1)) { currentAttack = AttackType.LK; attackDamage = 08; }
        else if (Input.GetKeyDown(KeyCode.Keypad2)) { currentAttack = AttackType.HK; attackDamage = 20; }
        else if (Input.GetKeyDown(KeyCode.Keypad0)) { currentAttack = AttackType.Block; block = true; }
        else currentAttack = AttackType.None;
    }

                if (currentAttack != AttackType.None)
                {
                    move = 0;
                    rig.velocity = new Vector2(move * speed, 0f);
                    anim.SetFloat("Walk", move);
                    anim.SetTrigger(currentAttack.ToString());
                    isAttack = true;
                }
            }
                private void OnTriggerEnter2D(Collider2D collision)
                {
                    move = 0;
                    rig.velocity = new Vector2(0f, 0f);
                    anim.SetFloat("Walk", move);
                    if (collision.gameObject.layer == 3)
                    {
                        if (block == true) { currentHealth -= attackDamage/4 ;}
                        else { currentHealth -= attackDamage;}
                        healthBar.SetHealth(currentHealth);
                        anim.SetBool("Knockback", true);
                        if (isPlayer1) { rig.velocity = new Vector2(-speed * 3, 0f); }
                        else { rig.velocity = new Vector2(speed * 3, 0f); }
                    }
                }
            }
