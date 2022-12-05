using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class vikingAgent : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    NavMeshAgent agent;
    RaycastHit raycastHit;

    [SerializeField] Vector3 movingDirection;
    [SerializeField] float jumpingForce, movingThreshold;

    Vector2 velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        animator=GetComponent<Animator>();
        agent=GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out raycastHit))
            {
                agent.SetDestination(raycastHit.point);
            }
        }

        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dz = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dz);
        velocity = deltaPosition / Time.deltaTime;
        if (velocity.magnitude > movingThreshold && agent.remainingDistance > agent.radius){
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }

    private void OnAnimatorMove()
    {
        transform.position = agent.nextPosition;
    }
}
