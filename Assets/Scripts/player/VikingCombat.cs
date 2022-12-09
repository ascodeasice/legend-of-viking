using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vikingCombat : MonoBehaviour
{
    Animator animator;
    float damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("attacking", false);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("attacking", true);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("enemy")&&animator.GetBool("attacking"))
        {
            other.gameObject.GetComponent<enemyLife>().takeDamage(damage);
        }
    }
}
