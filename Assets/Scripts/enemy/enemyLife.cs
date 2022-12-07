using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLife : MonoBehaviour
{
    // Start is called before the first frame updatef
    float life = 60;
    Animator animator;
    bool canTakeDamage = true;

    void noDamageAfterHit()
    {
        if (!canTakeDamage)
        {
            canTakeDamage = true;
        }
    }

    void Start()
    {
        animator=transform.GetComponent<Animator>();
        InvokeRepeating("noDamageAfterHit", 0, 1.0f);
    }

    public void takeDamage(float damage)
    {
        if (!canTakeDamage)
        {
            return;
        }

        life -= damage;
        canTakeDamage=false;
        if (life <= 0)
        {
            animator.SetBool("dead", true);
            GameObject enemySpawner=GameObject.FindGameObjectWithTag("enemySpawner");
            enemySpawner.GetComponent<enemySpawner>().enemyCount--;
        }
    }
}
