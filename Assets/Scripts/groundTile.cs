using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTile : MonoBehaviour
{
    groundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner=GameObject.FindObjectOfType<groundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.spawnTile();
    }
}
