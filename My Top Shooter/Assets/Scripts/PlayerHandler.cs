using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    Vector2 inputVector = Vector2.zero;
    Controller playerController;
    void Start()
    {
        playerController = GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        playerController.SetInputVector(inputVector);
    }
}
