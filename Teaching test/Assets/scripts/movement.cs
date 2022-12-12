using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float speed = 1;
    public LayerMask groundLayer;
    public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, speed);
        }
        if(Input.GetKey(KeyCode.S))
        {
           rb.AddForce(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
            
        }
        
    }

    bool isGrounded()
    {
        bool g = Physics.CheckSphere(transform.position, .6f, groundLayer);
        return g;
    }


}
