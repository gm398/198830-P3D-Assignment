using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKey(KeyCode.W))
        //{
        //    rb.AddForce(0, 0, speed);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    rb.AddForce(0, 0, -speed);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    rb.AddForce(-speed, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    rb.AddForce(speed, 0, 0);
        //}

        Move(KeyCode.W, cam.forward * speed);
        Move(KeyCode.S, cam.forward * -speed);
        Move(KeyCode.A, cam.right * -speed);
        Move(KeyCode.D, cam.right * speed);

    }

    void Move(KeyCode key, Vector3 direction)
    {
        if (Input.GetKey(key))
        {
            rb.AddForce(direction);
        }
    }
}
