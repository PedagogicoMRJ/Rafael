using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayerLeftGoal;
    private void OnTriggerEnter2D(Collider2D collison)
    {
         if (collison.gameObject.CompareTag("Ball"))
         {
            if(!isPlayerLeftGoal)
            {
                Debug.Log("Player Left Scored");
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerLeftScored();
            }
            else
            {
                    Debug.Log("Player Right Score");
                    GameObject.Find("GameManager").GetComponent<GameManager>().PlayerRightScored();

            }
         }
    }
}