using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class collectItem : MonoBehaviour
{
    // Start is called before the first frame update
    int coinCount = 0;
    [SerializeField] TextMeshProUGUI coinText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        // NOTE collect item with trigger or overlapSphere?
        if (other.gameObject.CompareTag("collectable"))
        {
            if (other.name.Contains("Coin") && Input.GetKey(KeyCode.F))
            {
                coinCount++;
                coinText.text=$"COIN:{coinCount}";
                GameObject.Destroy(other.transform.parent.gameObject);
            }                
        }
    }
}
