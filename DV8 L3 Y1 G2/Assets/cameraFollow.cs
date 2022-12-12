using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform camXAxis;
    public float mouseSensitivity;
    //Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //offset = this.transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float yRotation = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float xRotation = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //xRotation = Mathf.Clamp(xRotation, -90, 90);
        Vector3 angle = camXAxis.rotation.eulerAngles;
        angle.x += xRotation;
        angle.x = Mathf.Clamp(angle.x, -90, 90);
        //if (angle.x > 90)
        //{ angle.x = 90; }
        //if (angle.x < -90)
        //{ angle.x = -90; }
        camXAxis.rotation = Quaternion.Euler(angle);

        //camXAxis.Rotate(xRotation, 0, 0);
        this.transform.Rotate(0, yRotation, 0);
        this.transform.position = target.position;
    }
}
