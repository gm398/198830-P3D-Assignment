using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyFPSController : MonoBehaviour
{
    [SerializeField] float speed = 6;
    [SerializeField] float jumpForce = 6;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;

    [SerializeField] ParticleSystem particles;
    private Rigidbody rb;
    private Vector2 input;
    private Vector3 movementVector;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Need to freez rotation so the player do not flip over
        rb.freezeRotation = true;
    }
    private void Update()
    {
        //Cleanerway to get input
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetButton("Fire1"))
        {
            particles.enableEmission = true;
        }
        else { particles.enableEmission = false; }
    }
    private void FixedUpdate()
    {
        //Keep the movement vector aligned with the player rotation
        movementVector = input.x * transform.right * speed + input.y * transform.forward * speed;
        //Apply the movement vector to the rigidbody without effecting gravity
        rb.velocity = new Vector3(movementVector.x, rb.velocity.y, movementVector.z);
    }
    private bool IsGrounded()
    {
        //Simple way to check for ground
        if (Physics.CheckSphere(groundCheck.position, .5f, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
