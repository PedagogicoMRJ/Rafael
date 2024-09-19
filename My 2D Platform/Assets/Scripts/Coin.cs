using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int score;
    private Animator anim;
    public AudioSource audioCoin;
    void Start()
    {
         anim = GetComponent<Animator>();
    }

   private void OnTriggerEnter2D(Collider2D collision)
   {
        if (collision.gameObject.tag == "Player") 
        {
            GameManager.access.totalscore += score;
            GameManager.access.ScoreBoard();
            Destroy(gameObject);
            audioCoin.Play();
        }
   }
}
