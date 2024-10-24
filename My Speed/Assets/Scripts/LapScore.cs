using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LapScore : MonoBehaviour
{
    public Text lapCounter;
    public int lap;
    public static LapScore access;
    void Start()
    {
        access = this;
    }
    public void LapCounter()
    {
        lapCounter.text = lap.ToString();
    }
}
