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
    int dies;

    private bool aiming;
    void Start()
    {
        dies = 0;

        playerLive = true;

        playerController = GetComponent<Controller>();

        aiming = false;

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

            mouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            aiming = false;
        }
        playerController.SetVectors(inputVector, mouseVector, aiming);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ((collision.tag == "Enemy") || ((collision.tag == "BossAttack")))
        {

            playerLive = false;
            dies += 1;
            Debug.Log($"You died {dies} times");
            gameManager.EndScreen(playerLive);

        }
    }
}