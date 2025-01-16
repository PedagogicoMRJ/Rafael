using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    WaitForSeconds threeSec;
    public bool isPlayable;
    public bool isPlayer1;
    bool isAttack = false;
    bool isKnockback = false;
    //string attack = "None";
    public float knockback;
    private Animator anim;
    private Rigidbody2D rig;
    bool block = false;
    float move;
    int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;
    int attackDamage;
    public float speed;
    public GameObject Trophy;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rig = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        isPlayable = false;
        threeSec = new WaitForSeconds(3);
    }
    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            anim.SetBool("Defeat", true);
            StartCoroutine("Ending");
        }
        else
                {
                    if (isKnockback)
                    {
                        anim.SetBool("Knockback", false);
                        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                        {
                            isKnockback = false;
                        }
                    }
                    if (isAttack)
                    {
                        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                        {
                            isAttack = false;
                            block = false;
                        }
                    }
                }
    }
    void Update()
    {
        if (currentHealth > 0)
        {
            if (!isPlayable)
            {
                isPlayable = healthBar.finishCountdown;
            }
            else
            {
                if (!isAttack && !isKnockback)
                {
                    Movement();
                    Attack();
                }
            }
        }
    }
    void Movement()
    {
        // Captura a entrada com base no jogador

        if (isPlayer1)
        {
            move = Input.GetAxis("Horizontal1");
        }
        else
        {
            move = Input.GetAxis("Horizontal2");
        }
        rig.velocity = new Vector2(move * speed, 0.0f);
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
                 if (Input.GetKeyDown(KeyCode.Q)) { currentAttack = AttackType.LP; attackDamage = 04; }
            else if (Input.GetKeyDown(KeyCode.W)) { currentAttack = AttackType.HP; attackDamage = 12; }
            else if (Input.GetKeyDown(KeyCode.E)) { currentAttack = AttackType.LK; attackDamage = 08; }
            else if (Input.GetKeyDown(KeyCode.R)) { currentAttack = AttackType.HK; attackDamage = 24; }
            else if (Input.GetKeyDown(KeyCode.T)) { currentAttack = AttackType.Block; block = true; }
            else{
                currentAttack = AttackType.None;
                block = false;
            }
        }
        else
        {
                 if (Input.GetKeyDown(KeyCode.Keypad4)) { currentAttack = AttackType.LP; attackDamage = 04; }
            else if (Input.GetKeyDown(KeyCode.Keypad5)) { currentAttack = AttackType.HP; attackDamage = 12; }
            else if (Input.GetKeyDown(KeyCode.Keypad1)) { currentAttack = AttackType.LK; attackDamage = 08; }
            else if (Input.GetKeyDown(KeyCode.Keypad2)) { currentAttack = AttackType.HK; attackDamage = 24; }
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
        rig.velocity = new Vector2(0.0f, 0.0f);
        anim.SetFloat("Walk", move);
        if (collision.gameObject.layer == 10)
        {
            Debug.Log("Colisão");
            if (block == true)
            {
                currentHealth -= attackDamage / 4;
            }
            else
            {
                currentHealth -= attackDamage;
                if (currentHealth > 0)
                {
                    anim.SetBool("Knockback", true);
                    if (isPlayer1)
                    {
                        rig.velocity = new Vector2(knockback * (-1), 0.0f);
                    }
                    else
                    {
                        rig.velocity = new Vector2(knockback, 0f);
                    }
                    isKnockback = true;
                }
            }
            if (currentHealth >= 0)
            healthBar.SetHealth(currentHealth);
        }
    }
    IEnumerator Ending()
    {
        yield return threeSec;
        anim.SetBool("Defeat", false);
        SceneManager.LoadScene(0);
        Trophy.SetActive(true);
    }
}
