using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankMove : MonoBehaviour
{
    public float speed = 5, turnSpeed = 30;
    
    public Transform turret;


    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direc = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            direc += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direc -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }
        MoveTank(direc);

    }

    void MoveTank(Vector3 direction)
    {
        direction.y = 0;
        rb.velocity = direction * speed;
    }
}
