using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerController : MonoBehaviour
{
    public float speed = 5;
    public float gravity = -10;
    CharacterController controller;
    public Transform grounCheck;
    public LayerMask groundLayer;
    Vector3 direc;
    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        direc = transform.forward * vInput + transform.right * hInput;
        direc.y = gravity * Time.deltaTime;
        controller.Move(direc.normalized * speed * Time.deltaTime);

    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(grounCheck.position, .2f, groundLayer);
    }
}
