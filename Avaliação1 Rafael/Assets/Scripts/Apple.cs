using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Maçã morreu de morte comida");
        GameManager.access.totalscore += 1;
        GameManager.access.Scoreboard();
        Destroy(gameObject);
    }
}
