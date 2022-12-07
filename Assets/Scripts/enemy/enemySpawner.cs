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
    float spawnRange = 10;
    float intervalSeconds = 2;

    Vector3 playerPosition = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < maxEnemyCount)
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            xPosition = Random.Range(playerPosition.x - spawnRange, playerPosition.x + spawnRange);
            zPosition = Random.Range(playerPosition.z - spawnRange, playerPosition.z + spawnRange);
            Instantiate(enemyPrefab, new Vector3(xPosition, playerPosition.y, zPosition), Quaternion.identity);

            yield return new WaitForSeconds(intervalSeconds);
            enemyCount++;
        }
    }

}
