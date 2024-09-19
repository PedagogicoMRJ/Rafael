using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
  public int totalscore;
  public Text scoreboard;
  public Text scoreboard2;
  public static GameManager access;
  public GameObject gameover;
  public GameObject gamewin;

  void Start()
  {
    access = this; 
  }
  public void ScoreBoard()
  {
    scoreboard.text = totalscore.ToString();
    scoreboard2.text = totalscore.ToString();
  }
  public void GameOver()
  {
    gameover.SetActive(true);
  }
  public void Restart()
  {
    SceneManager.LoadScene("SampleScene");
  }
  public void GameWin()
  {
    gamewin.SetActive(true);
  }
}
