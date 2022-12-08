using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    float life = 100;
    bool canTakeDamage = true;
    [SerializeField] healthBar healthBar;
    float deathHeight = -70f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("noDamageAfterHit", 0, 1.0f);
    }
    private void Update()
    {
        if (transform.position.y <= deathHeight)
        {
            SceneManager.LoadScene("deathScene");
        }
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
        healthBar.setHealth(life);

        if (life <= 0)
        {
            SceneManager.LoadScene("deathScene");
        }
    }
}
