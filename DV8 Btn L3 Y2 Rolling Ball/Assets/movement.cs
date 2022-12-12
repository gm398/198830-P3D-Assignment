using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody ball;
    public float force = 5;
    public KeyCode up, down, left, right;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(up))
        {
            ball.AddForce(0, 0, force);
        }
        if (Input.GetKey(down))
        {
            ball.AddForce(0, 0, -force);
        }
        if (Input.GetKey(left))
        {
            ball.AddForce(-force, 0, 0);
        }
        if (Input.GetKey(right))
        {
            ball.AddForce(force, 0, 0);
        }
    }

  
}
