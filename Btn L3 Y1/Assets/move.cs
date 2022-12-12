using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, speed);
        }
    }
}
