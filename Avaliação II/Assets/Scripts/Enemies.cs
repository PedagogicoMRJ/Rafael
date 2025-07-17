using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int nEnemyTypes;
    public int nEnemies;
    public bool enemiesDied;
    public int enemiesKilled;
    public GameObject[] spawnEnemies;
    public EnemyHandler[] prefabs;
    int internalLevel;
    public EnemyHandler enemyHandler1;
    public EnemyHandler enemyHandler2;
    public bool youWin;
    // Start is called before the first frame update
    void Start()
    {
        youWin = false;
        internalLevel = 1;
        enemyHandler1.SetLevel(internalLevel);
        enemyHandler1.SetLevel(internalLevel);
        StartCoroutine(Enemy());
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesDied && internalLevel != 10)
        {
            enemiesDied = false;
            internalLevel++;
            StartCoroutine(Enemy());
        }
        if (internalLevel == 10)
        {
            youWin = true;
        }
    }
    IEnumerator Enemy()
    {
        yield return new WaitForSeconds(3);
        enemiesDied = false;
        for (int j = 0; j < nEnemyTypes; j++)
        {
            for (int i = 0; i < nEnemies * internalLevel; i++)
            {
                GameObject spawnPoint = GetRandomSpawnPoint();
                EnemyHandler enemy = Instantiate(this.prefabs[j], spawnPoint.transform);
                enemy.killed += EnemyKilled;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    public void EnemyKilled()
    {
        enemiesKilled++;
            if (enemiesKilled == nEnemies * nEnemyTypes)
            {
                enemiesDied = true;
            }
    }
    GameObject GetRandomSpawnPoint()
    {
        return spawnEnemies[Random.Range(0, spawnEnemies.Length)];
    }
}
