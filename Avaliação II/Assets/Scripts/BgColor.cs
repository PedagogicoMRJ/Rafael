using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgColor : MonoBehaviour
{
    Color green;
    Color magenta;
    Color bgColor;
    public Camera cam;
    float t;
    public int timeUntilChange;
    bool isPlayable;
    bool doTransitionPassed;
    PlayerHandler player1;
    PlayerHandler player2;
    Enemies enemies;
    void Start()
    {
        enemies = GameObject.FindGameObjectWithTag("Enemies").GetComponent<Enemies>();
        player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerHandler>();
        player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerHandler>();
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        isPlayable = true;
        doTransitionPassed = false;
        t = 0f;
        if (ColorUtility.TryParseHtmlString("#00bf00", out Color g))
            green = g;
        if (ColorUtility.TryParseHtmlString("#bf00bf", out Color m))
            magenta = m;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.isDead || player2.isDead)
        {
            isPlayable = false;
            if (!doTransitionPassed)
            {
                StartCoroutine(Transition());
            }
        }
        else if (enemies.youWin)
        {
            isPlayable = false;
            if (!doTransitionPassed)
            {
                StartCoroutine(Transition());
            }
        }
        else
        {
            t += Time.deltaTime * Mathf.Deg2Rad * 180 / timeUntilChange;
            bgColor = Color.Lerp(green, magenta, (Mathf.Sin(t) + 1f) / 2f);
            cam.backgroundColor = bgColor;
        }
    }
    IEnumerator Transition()
    {
        doTransitionPassed = true;
        t = 180f;
        for (int i = 0; i < 60; i++)
        {
            cam.backgroundColor = Color.Lerp(bgColor, new Color32(0, 0, 0, 255), (Mathf.Cos(t * Mathf.Deg2Rad) + 1f) / 2f);
            t += 3f;
            yield return new WaitForSeconds(0.016f);
        }
        cam.backgroundColor = Color.Lerp(bgColor, new Color32(0, 0, 0, 255), (Mathf.Cos(t * Mathf.Deg2Rad) + 1f) / 2f);
    }
}
