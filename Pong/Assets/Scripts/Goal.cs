using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayerLeftGoal;
    public AudioSource audiogoal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            audiogoal.Play();
            if (!isPlayerLeftGoal)
            {
                Debug.Log("PlayerLeftScored");
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerLeftScored();
            }
            else{
                Debug.Log("PlayerRightScored");
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerRightScored();
            }
        }
    }
}
