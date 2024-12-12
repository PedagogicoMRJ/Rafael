using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public bool finishCountdown = false;
    WaitForSeconds oneSec;
    public Text Timer1;
    public Text Timer2;
    public Text Timer3;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;
            fill.color = gradient.Evaluate(1f);
    }
    void Start()
    {
        oneSec = new WaitForSeconds(1);
        StartCoroutine("Countdown");
    }
    IEnumerator Countdown()
    {
        Timer1.gameObject.SetActive(true);
        Timer2.gameObject.SetActive(true);
        Timer3.gameObject.SetActive(true);
        Timer1.text = "3";
        Timer2.text = "3";
        Timer3.text = "3";
        yield return oneSec;
        Timer1.text = "2";
        Timer2.text = "2";
        Timer3.text = "2";
        yield return oneSec;
        Timer1.text = "1";
        Timer2.text = "1";
        Timer3.text = "1";
        yield return oneSec;
        Timer1.text = "Fight";
        Timer2.text = "Fight";
        Timer3.text = "Fight";
        yield return oneSec;
        finishCountdown = true;
        Timer1.gameObject.SetActive(false);
        Timer2.gameObject.SetActive(false);
        Timer3.gameObject.SetActive(false);
    }
}
