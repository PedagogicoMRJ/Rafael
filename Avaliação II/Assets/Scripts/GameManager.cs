using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager access;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject youLost;
    Enemies enemies;

    void Start()
    {
        access = this;
        enemies = GameObject.FindGameObjectWithTag("Enemies").GetComponent<Enemies>();
        gameOver.Renderer renderer = GetComponent<Renderer>();
        youWon.Renderer renderer = GetComponent<Renderer>();
        youLost.Renderer renderer = GetComponent<Renderer>();
    }
    void Update()
    {

    }
    IEnumerator End()
    {
        gameOver.SetActive(true);
        if (enemies.youWin)
        {
            youWon.SetActive(true);
        }
        if (player1.isDead || player2.isDead)
        {
            youLost.SetActive(true);
        }
    }
}
https://www.google.com/search?q=how+to+control+the+gameobject+opacity+in+code+unity&sca_esv=8fe472cf0c0bad30&ei=TDZsaMf-EoHS1sQPo7n7wAM&ved=0ahUKEwjH1Jf80quOAxUBqZUCHaPcHjgQ4dUDCBA&uact=5&oq=how+to+control+the+gameobject+opacity+in+code+unity&gs_lp=Egxnd3Mtd2l6LXNlcnAiM2hvdyB0byBjb250cm9sIHRoZSBnYW1lb2JqZWN0IG9wYWNpdHkgaW4gY29kZSB1bml0eTIFEAAY7wUyBRAAGO8FMgUQABjvBTIFEAAY7wUyBRAAGO8FSLQ-UNcUWLw0cAB4A5ABAJgBkAGgAb0KqgEEMC4xMbgBA8gBAPgBAZgCDaAC-ArCAgQQABhHwgIEECEYCpgDAOIDBRIBMSBAiAYBkAYIkgcEMi4xMaAH3i2yBwQwLjExuAfnCsIHBTAuNS44yAcu&sclient=gws-wiz-serp