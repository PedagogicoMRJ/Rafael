using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Bullet bulletParameters;
    float reloadTime;
    public float velocity = 5;
    Vector2 movement;
    Vector2 aim;
    Vector2 playerPosition;
    Vector2 aimDirection;
    bool isAiming;
    Rigidbody2D bodyRig;
    Animator anim;
    public GameObject crosshair;
    void Start()
    {
        reloadTime = .5f;
        bulletParameters = GetComponentInChildren<Bullet>();
        bodyRig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        crosshair.SetActive(false);
        Cursor.visible = false;
    }
    void Update()
    {
        reloadTime += Time.deltaTime;
        playerPosition = transform.position;
        if (isAiming)
            Aiming();
        else
            Movement();
        crosshair.transform.position = aim;
    }

    void Movement()
    {
        crosshair.SetActive(false);
        if (movement.x != 0 && movement.y != 0)
        {
            bodyRig.velocity = new Vector2(movement.x, movement.y) * 7f;
        }
        else
        {
            bodyRig.velocity = new Vector2(movement.x, movement.y) * 10f;
        }
        anim.SetBool("Aim", false);
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Magnitude", movement.magnitude);
    }
    public void SetInputVector(Vector2 inputVector)
    {
        movement.x = inputVector.x;
        movement.y = inputVector.y;
    }
    public void SetVectors(Vector2 inputVector, Vector2 mouseVector, bool aiming)
    {
        movement.x = inputVector.x;
        movement.y = inputVector.y;
        aim = mouseVector;
        isAiming = aiming;
    }
    public void Aiming()
    {
        aimDirection = aim - playerPosition;
        aimDirection.Normalize();
        crosshair.SetActive(true);
        bodyRig.velocity = Vector2.zero;
        anim.SetBool("Aim", true);
        anim.SetFloat("aimHorizontal", aimDirection.x);
        anim.SetFloat("aimVertical", aimDirection.y);
        crosshair.transform.position = aim;
        if (Input.GetMouseButton(0) && reloadTime >= .5f)
        {
            reloadTime = 0f;
            bulletParameters.fireBullet(aimDirection);
        }
    }
}
