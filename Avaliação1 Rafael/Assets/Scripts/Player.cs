using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       MovementX();
       MovementY(); 
    }
    void MovementX()
    {
        Vector3 movementX = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movementX*speed*Time.deltaTime;
    }
    void MovementY()
    {
        Vector3 movementY = new Vector3(0f,Input.GetAxis("Vertical"),0f);
        transform.position += movementY*speed*Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        Destroy(gameObject);
    }
}
