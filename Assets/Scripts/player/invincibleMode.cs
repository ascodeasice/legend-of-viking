using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibleMode : MonoBehaviour
{
    [SerializeField]int invincibleTime;
    int timeLeft = 5;
    public void StartInvincibleMode()
    {
        timeLeft = invincibleTime;
        transform.GetComponent<playerLife>().isInvincible = true;
        StartCoroutine(countDown());
    }

    IEnumerator countDown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }

        transform.GetComponent<playerLife>().isInvincible = false;
    }
}
