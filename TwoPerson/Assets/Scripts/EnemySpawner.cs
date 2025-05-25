using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform leftSpawn;
    private Transform rightSpawn;
    private bool isSpawning;

    public GameObject enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftSpawn = GameObject.Find("LeftSpawn").transform;
        rightSpawn = GameObject.Find("RightSpawn").transform;
        isSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSpawning)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    public IEnumerator SpawnEnemy()
    {
        isSpawning = true;
        // Wait for 2 seconds before spawning an enemy
        yield return new WaitForSeconds(4f);

        // Randomly choose a spawn point
        Transform spawnPoint = Random.Range(0, 2) == 0 ? leftSpawn : rightSpawn;

        // Instantiate the enemy at the chosen spawn point
        GameObject spawnedEnemy = Instantiate(enemy, spawnPoint.position, Quaternion.identity);

        isSpawning = false;
    }
}
