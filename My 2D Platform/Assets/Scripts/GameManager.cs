using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Rafa esqueceu a Biblioteca UI que precisa para não dar erro no "text" - Isa :)
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
public int totalscore;
public Text scoreboard;
public static GameManager access;

void Start()
{
    access = this; 
}
  public void ScoreBoard()
  {
    scoreboard.text = totalscore.ToString();
  }
  // Update is called once per frame
  void Update()
  {
      
  }
}
