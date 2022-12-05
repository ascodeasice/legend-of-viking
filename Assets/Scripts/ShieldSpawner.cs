using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    public GameObject shieldPrefab;
    public int count;

    List<Transform> shieldList;

    // Start is called before the first frame update
    void Start()
    {
        shieldList= new List<Transform>();
        for(int i = 0; i < count; i++)
        {
            // generate shields with prefab
            Transform  c= Instantiate(shieldPrefab.transform);

            // appear on the object position with script
            c.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
