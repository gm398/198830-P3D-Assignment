using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camController : MonoBehaviour
{
    public Transform body;
    public float mouseSensitivity = 500;
    Vector3 camRot;
    // Start is called before the first frame update
    void Start()
    {
        camRot = transform.localEulerAngles;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        float yRot = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        body.Rotate(0, yRot, 0);
        camRot.x -= xRot;
        camRot.x = Mathf.Clamp(camRot.x, -60, 60);
        transform.localEulerAngles = camRot;
    }
}
