using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject Ball;
    [Header("Player Left")]
    public GameObject LeftPlayer;
    public GameObject PlayerLeftGoal;
    [Header("Player Right")]
    public GameObject RightPlayer;
    public GameObject PlayerRightGoal;
    [Header("Score UI")]
    public GameObject PlayerLeftText;
    public GameObject PlayerRightText;
    private int PlayerLeftScore;
    private int PlayerRightScore;
    public void PlayerLeftScored()
    {
        PlayerLeftScore++;
        PlayerLeftText.GetComponent<TextMeshProUGUI>().text = PlayerLeftScore.ToString();
        ResetPosition();
    }
    public void PlayerRightScored()
    {
        PlayerRightScore++;
        PlayerRightText.GetComponent<TextMeshProUGUI>().text = PlayerRightScore.ToString();
        ResetPosition();
    }
    public void ResetPosition()
    {
        Ball.GetComponent<Ball>().Reset();
        LeftPlayer.GetComponent<Racket>().Reset();
        RightPlayer.GetComponent<Racket>().Reset();
    }
}
