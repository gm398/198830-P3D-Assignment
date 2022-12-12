using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform body;
    public float mouseSensitivity = 500f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yRot = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float xRot = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        this.transform.Rotate(-xRot, 0, 0);
        body.Rotate(0, yRot, 0);

    }
}
