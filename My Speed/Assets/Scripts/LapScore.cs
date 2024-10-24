using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LapScore : MonoBehaviour
{
    public Text lapCounter;
    public GameObject image;
    public int lap;
    public static LapScore access;
    void Start()
    {
        access = this;
        image.SetActive(false);
    }
    public void lapcounter()
    {
        lapCounter.text = lap.ToString();
    }
    void Update()
    {
        if (LapCounter.access.isRaceCompleted == true)
        {
            image.SetActive(true);
        }
    }
}
