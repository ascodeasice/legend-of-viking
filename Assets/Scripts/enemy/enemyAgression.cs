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
        Vector3 worldDeltaPosition = playerPosition - transform.position;
        // rotate towards player
        worldDeltaPosition.y = 0;
        var rotation = Quaternion.LookRotation(worldDeltaPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

        if (distanceWithPlayer <= attackDistance)
        {
            animator.SetBool("attack",true);
            // attack animation is end
            // TODO attack player
        }
        if (distanceWithPlayer <= chaseDistance)
        {
            
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is hurt");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is hurt");
        }

    }
}
