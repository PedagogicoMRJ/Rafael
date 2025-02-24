using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHandler : MonoBehaviour
{
 
Vector2 inputVector = Vector2.zero;
Vector2 mouseVector = Vector2.zero;
Controller playerController;

private bool aiming;
void Start()
{

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

}