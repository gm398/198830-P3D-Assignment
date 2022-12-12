using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    public Transform camHolder;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(camHolder.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(camHolder.forward * -speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(camHolder.right * -speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(camHolder.right * speed);
        }
    }
}
