using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// prevent removing componenets
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]

public class vikingController : MonoBehaviour
{
    public float jumpingForce;
    MeshRenderer mr;
    [SerializeField] float movingSpeed=10f;
    [SerializeField] float runningSpeed=15f;
    [SerializeField] AudioSource jumpSound;
    Rigidbody rb;
    bool onGround = false;
    Animator animator;

    float animatorWalkSpeed = 1;
    float animatorRunSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", 0f);

        bool shiftIsPressed = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += (shiftIsPressed?runningSpeed:movingSpeed) * Time.deltaTime * Camera.main.transform.forward;
            animator.SetFloat("speed", (shiftIsPressed?animatorRunSpeed:animatorWalkSpeed));
        }
        if (Input.GetKey(KeyCode.A))
        {

            transform.position += (shiftIsPressed ? runningSpeed : movingSpeed) * Time.deltaTime * Camera.main.transform.right*-1;
            animator.SetFloat("speed", (shiftIsPressed ? animatorRunSpeed : animatorWalkSpeed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += (shiftIsPressed?runningSpeed:movingSpeed) * Time.deltaTime * Camera.main.transform.forward*-1;
            animator.SetFloat("speed", (shiftIsPressed ? animatorRunSpeed : animatorWalkSpeed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += (shiftIsPressed?runningSpeed:movingSpeed) * Time.deltaTime * Camera.main.transform.right;
            animator.SetFloat("speed", (shiftIsPressed ? animatorRunSpeed : animatorWalkSpeed));
        }
        if (onGround && Input.GetKey(KeyCode.Space))
        {
            //rb.AddForce(jumpingForce * Vector3.up);
            rb.velocity = new Vector3(rb.velocity.x,jumpingForce,rb.velocity.z);
            animator.SetBool("jumping", true);

            if (!jumpSound.isPlaying)
            {
                jumpSound.Play();
            }
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
