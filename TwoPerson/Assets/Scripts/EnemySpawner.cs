using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform leftSpawn;
    private Transform rightSpawn;
    private bool isSpawning;
    public float spawnInterval = 7f; // Time in seconds between spawns
    public GameObject enemy;
    public GameObject flyingEnemy;
    public GameObject bigEnemy;
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
        yield return new WaitForSeconds(spawnInterval);

        // Randomly choose a spawn point
        Transform spawnPoint = Random.Range(0, 2) == 0 ? leftSpawn : rightSpawn;

        int enemyType = Random.Range(0, 10);
        Debug.Log("Enemy Roll: " + enemyType);

        if (spawnInterval <= 3f && enemyType >= 8)
        {
            //Spawn a big enemy
            GameObject spawnedEnemy = Instantiate(bigEnemy, spawnPoint.position, Quaternion.identity);
        }
        else if (spawnInterval <= 3f && enemyType >= 6 || spawnInterval <= 5f && enemyType >= 8)
        {
            //Spawn a flying enemy
            GameObject spawnedEnemy = Instantiate(flyingEnemy, spawnPoint.position + new Vector3(0, 4, 0), Quaternion.identity);
        }
        else
        {
            // Spawn a regular enemy
            GameObject spawnedEnemy = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        }
        isSpawning = false;
    }
}
