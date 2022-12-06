using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class enemyAgression : MonoBehaviour
{
    Vector3 playerPosition = Vector3.zero;
    [SerializeField] float chaseDistance;
    [SerializeField] float attackDistance;
    [SerializeField] float movingSpeed;
    int damping = 2;
    float distanceWithPlayer = -1;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        animator = GetComponent<Animator>();
    }

    void chasePlayer()
    {
        // if close enough, attack
        // else, move towards player

        if (distanceWithPlayer <= attackDistance)
        {
            animator.SetBool("attack",true);
            // attack animation is end
            //if (animator.GetCurrentAnimatorStateInfo(2).normalizedTime > 1)
            //{

            //}
            // TODO attack player
        }
        else if (distanceWithPlayer <= chaseDistance)
        {
            Vector3 worldDeltaPosition = playerPosition - transform.position;
            // rotate towards player
            worldDeltaPosition.y = 0;
            var rotation = Quaternion.LookRotation(worldDeltaPosition);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            // move towards player
            float dx = Vector3.Dot(Vector3.right, worldDeltaPosition);
            float dz = Vector3.Dot(Vector3.forward, worldDeltaPosition);
            transform.position += new Vector3(dx,0,dz ) * movingSpeed/Time.deltaTime/1000000;
            animator.SetBool("run", true);
        }
        else
        {
            // idle
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("run", false);
        animator.SetBool("attack", false);
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        distanceWithPlayer = Vector3.Distance(transform.position, playerPosition);

        chasePlayer();
    }

    private void OnAnimatorMove()
    {
        if (distanceWithPlayer <= attackDistance)
        {
            Debug.Log("player is hurt");
        }
        
    }
}
