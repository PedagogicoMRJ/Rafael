using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public bool isPlayer1;
    Vector2 moveInput;
    Transform transform
    public float speed;
    private float fireCooldown
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            moveInput.x = Input.GetAxis("Horizontal1")
            moveInput.y = input.GetAxis("Vertical1")
        }
        else
        {
            moveInput.x = Input.GetAxis("Horizontal2")
            moveInput.y = input.GetAxis("Vertical2")
        }
        Movement();
        Fire();
        fireCooldown += Time.deltaTime;
    }
    void Movement()
    {
        transform.position += moveInput * speed * Time.deltaTime
    }
    void Fire()
    {
        if (fireCooldown >= 0.5f && moveInput.KeyCode("spaceBar"))
        {
            Debug.Log($"Fire")
            fireCooldown = 0.5f
        }
}