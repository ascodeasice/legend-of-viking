using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLife : MonoBehaviour
{
    // Start is called before the first frame updatef
    float life =100;
    Animator animator;
    bool canTakeDamage = true;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] healthBar healthBar;
    Vector3 coinSpawnTransform=new Vector3(0,2.5f,0);

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

            // drop coin
            GameObject coin=Instantiate(coinPrefab, transform.position+coinSpawnTransform, Quaternion.Euler(90f, 0f, 0f));
            coin.transform.SetParent(transform);
        }
    }
}
