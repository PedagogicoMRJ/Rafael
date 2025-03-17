using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public GameManager gameManager;
    bool playerLive;
    Vector2 inputVector = Vector2.zero;
    Vector2 mouseVector = Vector2.zero;
    Controller playerController;
    private bool aiming;
    void Start()
    {
        playerController = GetComponent<Controller>();
        aiming = false;
        playerLive = true;
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            inputVector = Vector2.zero;
            mouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            aiming = true;
        }
        else
        {
            inputVector.x = Input.GetAxis("Horizontal");
            inputVector.y = Input.GetAxis("Vertical");
            playerController.SetInputVector(inputVector);
            mouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            aiming = false;
        }
        playerController.SetVectors(inputVector, mouseVector, aiming);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            playerLive = false;
            gameManager.EndScreen(playerLive);
        }
    }
}
