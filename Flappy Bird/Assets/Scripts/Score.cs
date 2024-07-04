using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameManager manage;
    // Start is called before the first frame update
    void Start()
    {
        manage = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        manage.score++;

        manage.scoreText.text = manage.score.ToString();
    }

}