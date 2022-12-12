using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMove : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0, 0, -force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(force, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-force, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, 10, 0, ForceMode.Impulse);
        }
    }
}
