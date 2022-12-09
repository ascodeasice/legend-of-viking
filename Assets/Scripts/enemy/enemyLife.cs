using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLife : MonoBehaviour
{
    // Start is called before the first frame updatef
    float life =100;
    Animator animator;
    bool canTakeDamage = true;
    [SerializeField] healthBar healthBar;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject invincibleItemPrefab;
    [SerializeField] GameObject healthItemPrefab;
    GameObject spawnItem; // item to drop
    Vector3 itemSpawnShift =new Vector3(0,2.5f,0);
    float invincibleItemProbability = 10;
    float healthItemProbability = 10;

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
        if (!canTakeDamage||animator.GetBool("dead"))
        {
            return;
        }
        
        life -= damage;
        canTakeDamage=false;
        healthBar.setHealth(life);

        if (life <= 0)
        {
            animator.SetBool("attack", false);
            animator.SetBool("dead", true);

            // allow enemySpawner spawn another enemy
            GameObject enemySpawner=GameObject.FindGameObjectWithTag("enemySpawner");
            enemySpawner.GetComponent<enemySpawner>().enemyCount--;

            // drop items
            float probability = Random.Range(1, 101);
            if (probability <= invincibleItemProbability)
            {
                spawnItem = Instantiate(invincibleItemPrefab, transform.position + itemSpawnShift, Quaternion.Euler(-90f, 0f, 0f));
            }
            else if (probability <= invincibleItemProbability + healthItemProbability)
            {
                spawnItem = Instantiate(healthItemPrefab, transform.position + itemSpawnShift, Quaternion.Euler(-90f, 0f, 0f));
            }
            else
            {
                spawnItem = Instantiate(coinPrefab, transform.position + itemSpawnShift, Quaternion.Euler(90f, 0f, 0f));
            }

            spawnItem.transform.SetParent(transform);
        }
    }
}
