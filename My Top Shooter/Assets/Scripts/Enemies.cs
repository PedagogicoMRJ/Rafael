using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public bool enemiesDied;
    public Teleport teleport;
    public int enemiesKilled;
    public EnemyHandler[] prefabs;
    void Start()
    {
        enemiesDied = false;
        for (int i=0; i<100; i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
