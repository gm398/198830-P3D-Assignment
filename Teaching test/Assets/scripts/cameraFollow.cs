
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    [SerializeField] Transform target;
    Rigidbody targetRb;
    Vector3 offset;
    public float lerpSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = target.GetComponent<Rigidbody>();
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        //transform.rotation = Quaternion.LookRotation(transform.position + targetRb.velocity, Vector3.up);
        transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed * Time.deltaTime);
    }
   

   
}
