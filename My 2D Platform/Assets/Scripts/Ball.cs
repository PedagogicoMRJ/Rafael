using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public float jump;
    public bool isjumping;
    private Rigidbody2D rig;
    private Animator anim;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }
    void Movement()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * speed * Time.deltaTime;
        if(Input.GetAxis("Horizontal") != 0)
        {
            if(Input.GetAxis("Horizontal") > 0)
            {
                transform.eulerAngles = new Vector3(0f,0f,0f);
            }
            else 
            {
                transform.eulerAngles = new Vector3(0f,180f,0f);
            }
        }
    }
    void Jump()
    {
       if(Input.GetButtonDown("Jump") && isjumping == false) 
        {
            rig.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer ==  6)
        {
            isjumping = false;
        }
    }
}
