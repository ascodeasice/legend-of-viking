using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// prevent removing componenets
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]

public class VikingController : MonoBehaviour
{
    public float jumpingForce;
    MeshRenderer mr;
    [SerializeField] float movingSpeed = 10f;
    [SerializeField] float torqueForce;
    [SerializeField] Vector3 torqueDirection;
    Rigidbody rb;
    bool onGround = false;
    Animator animator;
    bool run = false;
    AudioSource footstep;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        footstep = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", 0f);

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetFloat("speed", movingSpeed);
            transform.position += movingSpeed * Time.deltaTime * Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += movingSpeed * Time.deltaTime * Vector3.left;
            animator.SetFloat("speed", movingSpeed);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += movingSpeed * Time.deltaTime * Vector3.back;
            animator.SetFloat("speed", movingSpeed);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += movingSpeed * Time.deltaTime * Vector3.right;
            animator.SetFloat("speed", movingSpeed);

        }
        if (onGround && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(jumpingForce * Vector3.up);
            animator.SetBool("jumping", true);
        }
        if (Input.GetKey(KeyCode.F))
        {
            rb.AddTorque(torqueForce * torqueDirection);
        }
        if(run&&!footstep.isPlaying)
        {
            footstep.Play();
        }
        if (run && footstep.isPlaying)
        {
            footstep.Stop();
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            animator.SetBool("jumping", false); 
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
