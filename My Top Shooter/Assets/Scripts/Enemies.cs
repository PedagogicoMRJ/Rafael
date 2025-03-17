using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public bool enemiesDied;
    public Teleport teleport;
    public int enemiesKilled;
    public GameObject[] spawnEnemies;
    public EnemyHandler[] prefabs;
    void Start()
    {
        enemiesDied = false;
        for (int i=0; i<100; i++)
        {
            GameObject spawnPoint = GetRandomSpawnPoint();
            Vector3 position = new Vector3(Random.Range(-100f,100f),Random.Range(-100f,100f),0f);
            EnemyHandler enemy = Instantiate(this.prefabs[0], this.transform);
            enemy.killed += EnemyKilled;
            enemy.transform.localPosition = position;
        }
    }
    public void EnemyKilled()
    {
        enemiesKilled++;
        if (enemiesKilled == 100)
        {
            
        }
        teleport.IsActive(enemiesDied);
    }
    GameObject GetRandomSpawnPoint()
    {
        return spawnEnemies[Random.Range(0, spawnEnemies.Length)];
    }
}

