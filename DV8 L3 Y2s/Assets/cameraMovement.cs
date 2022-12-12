using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform target;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - target.position;
    }

    // Update is called once per frame4
    void Update()
    {
        this.transform.position = target.position + offset;
    }
}
