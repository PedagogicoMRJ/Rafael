using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isFinalLevel;
    public int level;
    public GameObject canvas;
    public GameObject win;
    public GameObject lose;
    bool winner;
    float time = 0;
    bool endScreen;
    void Start()
    {
        level++;
        Time.timeScale = 1;
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
                if (isFinalLevel)
                    SceneManager.LoadScene("Menu");
                else
                    SceneManager.LoadScene("Lv" + level);
            }
        }
    }
    public void EndScreen(bool youWin)
    {
        Time.timeScale = 0;
        winner = youWin;
        endScreen = true;
        canvas.SetActive(true);
        bool loser = !winner;
        win.SetActive(winner);
        win.SetActive(loser);
    }
}
