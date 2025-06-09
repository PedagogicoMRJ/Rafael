using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public int level = 1;
    bool timer;
    float realTimer;
    public GameManager gameManager;
    bool winner;
    CircleCollider2D circleCollider;
    bool isActive;
    Animator anim;
    void Start()
    {
        timer = false;
        anim = GetComponent<Animator>();
        winner = false;
        isActive = false;
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.enabled = false;
    }
    void Update()
    {
        realTimer += Time.deltaTime;
    }

    // Update is called once per frame
    public void IsActive(bool active)
    {
        isActive = active;
        if (isActive)
        {
            circleCollider.enabled = true;
            winner = true;
            anim.SetTrigger("IsActive");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((isActive) && collision.tag == "Player")
        {
            if (!timer)
            {
            timer = true;
            realTimer = 0f;
            }
            if (timer)
            {
                anim.SetTrigger("Activate");
                if (realTimer >= 0.67f)
                {
                    gameManager.EndScreen(winner);
                }
            }
        }
    }
}