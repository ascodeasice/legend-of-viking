using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class groundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint=Vector3.zero;
    int sideCount = 8;


    bool tileExists(Vector3 position)
    {
        Collider[] intersecting = Physics.OverlapSphere(position, 1f);
        return intersecting.Length > 0; 
    }

    public void spawnTile()
    {
        for(int i = 0; i < sideCount; i++)
        {
            nextSpawnPoint = transform.GetChild(i).transform.position;
            if (tileExists(nextSpawnPoint))
            {
                continue;
            }
            Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        }
    }

    void Start()
    {
        if (gameObject.name == "startGround")
        {
            spawnTile();
        }
    }

    // spawn tiles nearby when entering it
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spawnTile();
        }
    }
}
