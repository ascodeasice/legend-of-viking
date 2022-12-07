using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectItem : MonoBehaviour
{
    // Start is called before the first frame update
    int coinCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // NOTE collect item with trigger or overlapSphere?
        if (other.gameObject.CompareTag("collectable"))
        {
            if (other.name.Contains("Coin"))
            {
                coinCount++;
                Debug.Log(coinCount);
                GameObject.Destroy(other.gameObject);
            }                
        }
    }
}
