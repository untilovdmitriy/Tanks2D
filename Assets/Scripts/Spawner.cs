using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public int enemyCount = 1;
    public Transform enemy;
    public Transform player;

    float respawnTimer = 2.0f;

    void Start()
    {
        SpawnEnemies();
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        Instantiate(player, GameObject.Find("PlayerSpawn").transform.position, transform.rotation);
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemy, GameObject.Find("EnemySpawn").transform.position, transform.rotation);
        }
    }

    void Update()
    {
        if (respawnTimer > 0)
        {
            respawnTimer -= Time.deltaTime;
        }
        else
        {
            respawnTimer = 2.0f;
            if (GameObject.FindGameObjectWithTag("Player") == null) SpawnPlayer();
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) SpawnEnemies();
        }
    }
}