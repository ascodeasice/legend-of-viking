using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerLife : MonoBehaviour
{
    float life = 100;
    bool canTakeDamage = true;
    [SerializeField] TextMeshProUGUI hpText;

    // Start is called before the first frame update
    void Start()
    {
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
        hpText.text = $"HP:{life}/100";
        canTakeDamage = false;
        if (life <= 0)
        {
            // TODO canvas show player's dead
        }
    }
}
