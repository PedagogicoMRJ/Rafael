using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        SceneManager.LoadScene("Lv1");
    }
    public void Quit()
    {
        SceneManager.LoadScene("Quit");
    }
    public void Return()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ReallyQuit()
    {
        SceneManager.LoadScene("ReallyQuit");
    }
    public void RealQuit()
    {
        SceneManager.LoadScene("RealQuit");
    }
    public void TrueQuit()
    {
        Application.Quit();
    }
}
