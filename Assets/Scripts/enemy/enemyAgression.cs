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
    bool dead = false;

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
        }
        if (distanceWithPlayer <= chaseDistance)
        {
            // move towards player
            float dx = Vector3.Dot(Vector3.right, worldDeltaPosition);
            float dz = Vector3.Dot(Vector3.forward, worldDeltaPosition);
            transform.position += new Vector3(dx,0,dz ) * movingSpeed/Time.deltaTime/10000;
            Debug.Log(transform.position);
            animator.SetBool("run", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        dead = animator.GetBool("dead");
        if (dead)
            return;
        animator.SetBool("run", false);
        animator.SetBool("attack", false);
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        distanceWithPlayer = Vector3.Distance(transform.position, playerPosition);

        chasePlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (dead)
            return;
        if (collision.gameObject.CompareTag("Player"))
        {
            var healthComponent = collision.gameObject.GetComponent<playerLife>();
            healthComponent.takeDamage(10);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (dead)
            return;
        if (collision.gameObject.CompareTag("Player"))
        {
            var healthComponent = collision.gameObject.GetComponent<playerLife>();
            healthComponent.takeDamage(10);
        }
    }
}
