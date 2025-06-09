using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Boss boss;
    public Slider slider;
    public void SetmaxHealth(int health)
    {
        StartCoroutine(SetMaxHealth(health));
    }
    IEnumerator SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = 0;
        for (int i = 0; i < health/10; i++)
        {
            slider.value += 20;
            yield return new WaitForSeconds(0.05f);
        }
        boss.CountDown();
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
