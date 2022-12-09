using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int maxEnemyCount;
    float xPosition;
    float zPosition;
    public int enemyCount;
    float spawnRange = 20;
    [SerializeField] float intervalSeconds;
    [SerializeField] float minIntervalSeconds = 1;
    float waitSeconds=5;

    Vector3 playerPosition = Vector3.zero;
    bool hasWaited=false;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }



    IEnumerator EnemySpawn()
    {
        if (!hasWaited)
        {
            yield return new WaitForSeconds(waitSeconds);
        }
        while (true)
        {
            if (enemyCount >= maxEnemyCount)
            {
                yield return new WaitForSeconds(intervalSeconds);
                continue;
            }


            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            xPosition = Random.Range(playerPosition.x - spawnRange, playerPosition.x + spawnRange);
            zPosition = Random.Range(playerPosition.z - spawnRange, playerPosition.z + spawnRange);
            Instantiate(enemyPrefab, new Vector3(xPosition, playerPosition.y, zPosition), Quaternion.identity);

            yield return new WaitForSeconds(intervalSeconds);
            if (intervalSeconds * 0.9f > minIntervalSeconds)
            {
                intervalSeconds *= 0.9f;
            }
            else
            {
                intervalSeconds = minIntervalSeconds;
            }

            enemyCount++;
        }
    }

}
