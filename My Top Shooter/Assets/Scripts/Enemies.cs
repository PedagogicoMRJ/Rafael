using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : MonoBehaviour
{
    public Text Lv;
    public Text START;
    public int nEnemyTypes;
    public int level;
    public int nEnemies;
    public bool enemiesDied;
    public Teleport teleport;
    public int enemiesKilled;
    public GameObject[] spawnEnemies;
    public EnemyHandler[] prefabs;
    private bool isPlayable;
    void Update()
    {
        if (isPlayable)
        {
            StartCoroutine(STart());
            isPlayable = false;
        }
    }
    void Start()
    {
        isPlayable = false;
        StartCoroutine(Countdown());
    }
    IEnumerator STart()
    {
        enemiesDied = false;
        for (int j = 0; j < nEnemyTypes; j++)
        {
            for (int i = 0; i < nEnemies; i++)
            {
                GameObject spawnPoint = GetRandomSpawnPoint();
                EnemyHandler enemy = Instantiate(this.prefabs[j], this.transform);
                enemy.killed += EnemyKilled;
                enemy.transform.localPosition = spawnPoint.transform.position;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    public void EnemyKilled()
    {
        enemiesKilled++;
        if (level != 3)
        {
            if (enemiesKilled == nEnemies * nEnemyTypes)
            {
                enemiesDied = true;
            }
        }
        teleport.IsActive(enemiesDied);
    }
    GameObject GetRandomSpawnPoint()
    {
        return spawnEnemies[Random.Range(0, spawnEnemies.Length)];
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        Lv.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        START.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Lv.gameObject.SetActive(false);
        START.gameObject.SetActive(false);
        isPlayable = true;
    }
}

