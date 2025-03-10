using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject win;
    public GameObject lose;
    bool winner;
    float time = 0;
    bool endScreen;
    void Start()
    {
        winner = false;
        endScreen = false;
        canvas.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
    }
    void Update()
    {
        if (endScreen)
        {
            time += Time.deltaTime;
            if (time > 5f)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
    public void EndScreen(bool youWin)
    {
        winner = youWin;
        time = 0;
        endScreen = true;
        canvas.SetActive(true);
        bool loser = !winner;
        win.SetActive(winner);
        win.SetActive(loser);
    }
}
