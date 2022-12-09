using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class playerLife : MonoBehaviour
{
    public float life = 100;
    bool canTakeDamage = true;
    [SerializeField] healthBar healthBar;
    [SerializeField] Image fill;
    float deathHeight = -70f;
    public bool isInvincible = false;


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

        if (isInvincible)
        {
            fill.color = Color.cyan;
            canTakeDamage = false;
        }
    }

    void noDamageAfterHit()
    {
        if (isInvincible)
        {
            return;
        }

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

    public void setHealth(float value)
    {
        value = Mathf.Clamp(value, 0, 100);
        life = value;
        healthBar.setHealth(value);
    }
}
