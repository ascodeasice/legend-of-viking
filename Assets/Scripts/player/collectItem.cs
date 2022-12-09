using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class collectItem : MonoBehaviour
{
    // Start is called before the first frame update
    public static int coinCount = 0;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] playerLife lifeScript;
    [SerializeField] AudioSource coinSound;
    [SerializeField] AudioSource collectSound;

    private void OnTriggerStay(Collider other)
    {
        // NOTE collect item with trigger or overlapSphere?
        if (other.gameObject.CompareTag("collectable"))
        {
            if (!Input.GetKey(KeyCode.F))
            {
                return;
            }
            if (other.name.Contains("Coin") )
            {
                coinCount++;
                coinText.text = $"COIN:{coinCount}";
                coinSound.Play();
                GameObject.Destroy(other.transform.parent.gameObject);
            }
            else if (other.name.Contains("invincible"))
            {
                transform.GetComponent<invincibleMode>().StartInvincibleMode();
                collectSound.Play();
                GameObject.Destroy(other.transform.parent.gameObject);
            }
            else if (other.name.Contains("healthItem"))
            {
                lifeScript.setHealth(lifeScript.life + 10);
                collectSound.Play();
                GameObject.Destroy(other.transform.parent.gameObject);
            }
        }
    }
}
