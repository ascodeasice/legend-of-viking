using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLife : MonoBehaviour
{
    float life = 100;
    bool canTakeDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        takeDamage(10);
        InvokeRepeating("noDamageAfterHit", 0, 1.0f);
    }

    void noDamageAfterHit()
    {
        if (!canTakeDamage)
        {
            canTakeDamage = true;
        }
    }

    public void takeDamage(float damage)
    {
        if (!canTakeDamage)
        {
            return;
        }

        life -= damage;
        canTakeDamage = false;
        Debug.Log($"PlayerLife: {life}");
        if (life <= 0)
        {
            // TODO canvas show player's dead
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
