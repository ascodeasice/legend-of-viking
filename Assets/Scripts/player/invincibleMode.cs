using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibleMode : MonoBehaviour
{
    [SerializeField]int invincibleTime;
    [SerializeField] playerLife playerLifeScript;
    int timeLeft = 5;
    public void StartInvincibleMode()
    {
        timeLeft = invincibleTime;
        // if coroutine is running, update the time instead of starting again
        if (playerLifeScript.isInvincible)
        {
            timeLeft=invincibleTime;
        }
        else
        {
            playerLifeScript.isInvincible = true;
            StartCoroutine(countDown());
        }
    }

    IEnumerator countDown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }

        transform.GetComponent<playerLife>().isInvincible = false;
        playerLifeScript.setHealth(playerLifeScript.life);
    }
}
