using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    [SerializeField] GameObject[] miniEnemy;
    [SerializeField] GameObject bossEnemy;
    [SerializeField] float spawnRange = 20.0f;
    [SerializeField] int enemyCount;
    [SerializeField] int waveNumber;
    [SerializeField] int bossRound;

    void Start()
    {
        //ABSTRACTION
        SpawnEnemyWave(waveNumber);
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            if (waveNumber % bossRound == 0)
            {
                //ABSTRACTION
                SpawnBossWave(waveNumber);
            }
            else
            {
                //ABSTRACTION
                SpawnEnemyWave(waveNumber);
            }
        }
    }

    //ABSTRACTION
    void SpawnBossWave(int currentRound)
    {
        int miniEnemyToSpawn;

        if (bossRound != 0)
        {
            miniEnemyToSpawn = currentRound / bossRound;
        }
        else
        {
            miniEnemyToSpawn = 1;
        }

        var boss = Instantiate(bossEnemy, GenerateBossRandomPosition(), bossEnemy.transform.rotation);
        boss.GetComponent<ZombieBoss>().miniEnemySpawnCount = miniEnemyToSpawn;
    }

    public void SpawnMiniEnemy(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int randomMini = Random.Range(0, miniEnemy.Length);
            Instantiate(miniEnemy[randomMini], GenerateRandomPosition(), miniEnemy[randomMini].transform.rotation);
        }

    }

    //ABSTRACTION
    void SpawnEnemyWave(int enemyToSpawn)
    {
        for (int i = 0; i < enemyToSpawn; i++)
        {
            int randomEnemy = Random.Range(0, enemy.Length);

            Instantiate(enemy[randomEnemy], GenerateRandomPosition(), enemy[randomEnemy].transform.rotation);
        }
    }

    //ABSTRACTION
    private Vector3 GenerateRandomPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(spawnPosX, 1, spawnPosZ);

        return spawnPos;
    }

    //ABSTRACTION
    private Vector3 GenerateBossRandomPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(spawnPosX, 3, spawnPosZ);

        return spawnPos;
    }
}
