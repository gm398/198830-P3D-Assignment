using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * speed * zInput * Time.deltaTime 
            + transform.right * speed * xInput * Time.deltaTime;
        movement.y = -2f;
        controller.Move(movement);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            BroadcastMessage("SetShooting", true, SendMessageOptions.DontRequireReceiver);
        }
        else
        { BroadcastMessage("SetShooting", false, SendMessageOptions.DontRequireReceiver); }
    }
}
