using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
 
  Vector2 playerPosition;
  Vector2 aimDirection;
  public float velocity = 5;

  Vector2 movement;
  Vector2 aim;
  bool isAiming;
  Animator anim;
  Rigidbody2D bodyRig;
  public GameObject crossHair;
  void Start()
  {
      anim = GetComponentInChildren<Animator>();
     
      bodyRig = GetComponent<Rigidbody2D>();
      
      crossHair.SetActive(false);

      Cursor.visible = false;

  }

  void Update()
  {
    
    playerPosition = transform.position;
    
    if(isAiming)
    {

      Aiming();

    }
    else
    {

      Movement();

    }
    

  }

   void Movement()
   {
     
     crossHair.SetActive(false);

     if (movement.x != 0 && movement.y != 0)
     {

       bodyRig.velocity = new Vector2(movement.x, movement.y) * velocity * 0.7f;

     }
     else
     {

       bodyRig.velocity = new Vector2(movement.x, movement.y) * velocity;

     }

     anim.SetBool("Aim" , false);

     anim.SetFloat("Horinzontal" , movement.x);

     anim.SetFloat("Vertical" , movement.y);

     anim.SetFloat("Magnitude" , movement.magnitude);

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

  crossHair.SetActive(true);

  bodyRig.velocity = Vector2.zero;
  
  anim.SetBool("Aim", true);

  anim.SetFloat("AimHorizontal", aimDirection.x);

  anim.SetFloat("AimVertical" , aimDirection.y);

  anim.SetFloat("Magnitude" , movement.magnitude);

  crossHair.transform.position = aim;

}
}
