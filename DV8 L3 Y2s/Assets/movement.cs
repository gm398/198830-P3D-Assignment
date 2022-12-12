using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    
    // Update is called once per frame
    void Update()
    {
        Move(0, 0, speed, KeyCode.W);
        Move(0, 0, -speed, KeyCode.S);
        Move(-speed, 0, 0, KeyCode.A);
        Move(speed, 0, 0, KeyCode.D);
        Move(speed, 0, speed, KeyCode.E);


        int result = add(5, 10);
    }

    void Move(float x, float y, float z, KeyCode key)
    {
        if (Input.GetKey(key))
        {
            rb.AddForce(x, y, z);
            rb.AddForce(0, 10, 0);
        }
    }

    int add(int x, int y)
    {
        return x + y;
    }


  
}
