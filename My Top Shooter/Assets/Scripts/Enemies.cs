using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    WaitForSeconds cooldown;
    public int nEnemies;
    public bool enemiesDied;
    public Teleport teleport;
    public int enemiesKilled;
    public GameObject[] spawnEnemies;
    public EnemyHandler[] prefabs;
    void Update()
    {

    }
    void Start()
    {
        enemiesDied = false;
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < nEnemies; i++)
            {
                GameObject spawnPoint = GetRandomSpawnPoint();
                EnemyHandler enemy = Instantiate(this.prefabs[j], this.transform);
                enemy.killed += EnemyKilled;
                enemy.transform.localPosition = spawnPoint.transform.position;
                cooldown = new WaitForSeconds(1);
                StartCoroutine("Cooldown");
            }
        }
    }
    public void EnemyKilled()
    {
        enemiesKilled++;
        if (enemiesKilled == nEnemies * 3)
        {
            enemiesDied = true;
        }
        teleport.IsActive(enemiesDied);
    }
    GameObject GetRandomSpawnPoint()
    {
        return spawnEnemies[Random.Range(0, spawnEnemies.Length)];
    }
    IEnumerator Cooldown()
    {
        yield return cooldown;
    }
}

