using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingCombat : MonoBehaviour
{
    Animator animator;
    bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("attacking", false);
        if (!onGround)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("attacking", true);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = false;
        }
    }
}
