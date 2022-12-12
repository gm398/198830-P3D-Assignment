using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    //Vector3 offset;

    public float mouseSensitivity;
    // Start is called before the first frame update
    void Start()
    {
        //offset = this.transform.position - target.position;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float rotx = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        this.transform.Rotate(0, rotx, 0);
        this.transform.position = target.position;
    }
}
