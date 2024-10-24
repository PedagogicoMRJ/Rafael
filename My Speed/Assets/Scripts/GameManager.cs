using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject image;
    void Start()
    {
        SceneManager.LoadScene("Game");
    }
    public void Startgame()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Game");
    }
    void Update()
    {
        if (LapCounter.access.isRaceCompleted == true)
        {
            image.SetActive(true);
        }
    }
}
