using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public Enemy[] enemyPrefabs; // Assign 4 enemy prefabs in Inspector
    public float spawnInterval = 1f;  // Time between spawns
    public int maxEnemies = 10;       // Max number of enemies at a time

    private int currentEnemies = 0;
    public float spawnDistance = 30f;  // Distance from player

    private Dictionary<string, List<Enemy>> enemies = new Dictionary<string, List<Enemy>>();
    void Start()
    {
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            PoolManager.Instance.CreatePool<Enemy>("Enemy " + i.ToString(), enemyPrefabs[i], 1);
        }
        StartCoroutine(SpawnEnemies());
        
    }

    private void FixedUpdate()
    {

    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            if (GameManager.Instance.CurrentState != GameState.Playing)
            {

            }
            else
            {
                if (currentEnemies < maxEnemies)
                {
                    SpawnEnemy();
                }
            }
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0) return;

        int index = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPosition = GetSpawnPositionAroundPlayer();
        string enemyKey = "Enemy " + index.ToString();
        Enemy enemy = PoolManager.Instance.GetObject<Enemy>(enemyKey, spawnPosition, Quaternion.identity);
        if(enemy != null) {
            if (!enemies.ContainsKey(enemyKey))
            {
                enemies.Add(enemyKey, new List<Enemy>());
            }

            if (!enemies[enemyKey].Contains(enemy))
            {
                enemies[enemyKey].Add(enemy);
            }

            enemy.gameObject.SetActive(true);
            enemy.onDeath += () => currentEnemies--;
            currentEnemies++;
        }
        else
        {
            Debug.Log("Error");
        }
    }

    Vector3 GetSpawnPositionAroundPlayer()
    {
        float angle = Random.Range(0f, 360f); // Random direction
        float radians = angle * Mathf.Deg2Rad;

        // Calculate position at the given distance around the player
        Vector3 offset = new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians)) * spawnDistance;
        return PlayerManager.Instance.transform.position + offset;
    }

    public void DeactiveEnemy()
    {
        foreach (var pair in enemies)
        {
            string enemyType = pair.Key;
            List<Enemy> enemyList = pair.Value;


            foreach (Enemy enemy in enemyList)
            {
                PoolManager.Instance.ReturnObject<Enemy>(enemyType, enemy);
            }
        }

    }
}
