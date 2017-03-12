using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject enemyPrefab;
    private GameObject enemy;
    public int totalEnemy = 5;
    [HideInInspector]
    public int currentEnemyNo = 0;
    [HideInInspector]
    public int currentAlive = 0;
    [HideInInspector]
    public bool allDead = false;


	void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        if(currentEnemyNo == totalEnemy)
        {
            StopCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        float refreshRate = 1.0f;
        while(currentEnemyNo != totalEnemy)
        {
            currentAlive++;
            enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = (transform.position);
            currentEnemyNo++;

            yield return new WaitForSeconds(refreshRate);
        }
    }

    public void EnemyKilled()
    {
        currentAlive--;
        if(currentAlive == 0)
        {
            allDead = true;
        }
    }
}
