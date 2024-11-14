using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager access;
    public bool isPlayerDead;
    public int totalscore;
    public Text scoreboard;
    void Start()
    {
        access = this;
        isPlayerDead = false;
    }
    void Update()
    {
        if (isPlayerDead == true){
            SceneManager.LoadScene("SampleScene");
        }
        //PlayerDead();
    }

    // Update is called once per frame
    /*public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }*/
    public void PlayerDead()
    {
        if (isPlayerDead == true)
            SceneManager.LoadScene("SampleScene");
            //Restart();
    }
    public void Scoreboard()
    {
        scoreboard.text = totalscore.ToString();
    }
}
