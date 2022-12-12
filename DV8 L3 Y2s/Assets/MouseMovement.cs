using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSesitivity;
    public Transform camHolder;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X") * mouseSesitivity;
        camHolder.Rotate(0, xRot, 0);
        float yRot = Input.GetAxis("Mouse Y") * mouseSesitivity;
        this.transform.Rotate(-yRot, 0, 0);
    }
}
