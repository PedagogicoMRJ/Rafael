using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    enum moveDir
    {
        Right = 2,
        RightDown = 3,
        Down = 4,
        LeftDown = 5,
        Left = 6,
        LeftUp = 7,
        Up = 0,
        RightUp = 1,
    }
    moveDir currentDir;
    public bool isPlayer1;
    bool fireInput;
    Vector2 moveInput;
    Transform transform;
    Rigidbody2D rig;
    public float speed;
    private float fireCooldown;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    int fireAngle;
    Vector2 fireDir;
    void Start()
    {
        transform = GetComponent<Transform>();
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isPlayer1)
        {
            moveInput.x = Input.GetAxis("Horizontal1");
            moveInput.y = Input.GetAxis("Vertical1");
            if (Input.GetKey("space"))
                fireInput = true;
            else
                fireInput = false;
        }
        else
        {
            moveInput.x = Input.GetAxis("Horizontal2");
            moveInput.y = Input.GetAxis("Vertical2");
            if (Input.GetKey("right shift"))
                fireInput = true;
            else
                fireInput = false;
        }
        Movement();
        Fire();
        fireCooldown += Time.deltaTime;
        if (moveInput.x > 0 && moveInput.y > 0)
            currentDir = moveDir.RightUp;
        else if (moveInput.x > 0 && moveInput.y == 0)
            currentDir = moveDir.Right;
        else if (moveInput.x > 0 && moveInput.y < 0)
            currentDir = moveDir.RightDown;
        else if (moveInput.x == 0 && moveInput.y > 0)
            currentDir = moveDir.Up;
        else if (moveInput.x == 0 && moveInput.y < 0)
            currentDir = moveDir.Down;
        else if (moveInput.x < 0 && moveInput.y > 0)
            currentDir = moveDir.LeftUp;
        else if (moveInput.x < 0 && moveInput.y == 0)
            currentDir = moveDir.Left;
        else if (moveInput.x < 0 && moveInput.y < 0)
            currentDir = moveDir.LeftDown;
    }
    void Movement()
    {
        if (currentDir == moveDir.Right || currentDir == moveDir.Down || currentDir == moveDir.Left || currentDir == moveDir.Up)
        {
            rig.velocity = new Vector2(moveInput.x, moveInput.y) * speed;
        }
        if (currentDir == moveDir.RightUp || currentDir == moveDir.RightDown || currentDir == moveDir.LeftDown || currentDir == moveDir.LeftUp)
        {
            rig.velocity = new Vector2(moveInput.x, moveInput.y) * 0.7f * speed;
        }
    }
    void Fire()
    {
        if (fireCooldown >= 0.5f && fireInput == true && moveInput.magnitude != 0f)
        {
            fireCooldown = 0f;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            int quadrant = (int)currentDir;
            fireAngle = quadrant * 45;
            fireDir = new Vector2(Mathf.Sin(fireAngle * Mathf.Deg2Rad), Mathf.Cos(fireAngle * Mathf.Deg2Rad));
            bullet.GetComponent<Rigidbody2D>().velocity = fireDir * bulletSpeed;
        }
    }
}