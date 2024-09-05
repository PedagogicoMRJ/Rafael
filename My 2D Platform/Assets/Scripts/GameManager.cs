using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
  public int totalscore;
  public Text scoreboard;
  public static GameManager access;
  public GameObject gameover;

  void Start()
  {
    access = this; 
  }
  public void ScoreBoard()
  {
    scoreboard.text = totalscore.ToString();
  }
  public void GameOver()
  {
    gameover.SetActive(true);
  }
  public void Restart()
  {
    SceneManager.LoadScene("SampleScene");
  }
}
