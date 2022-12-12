using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    [SerializeField] Transform exit;


    private void OnTriggerEnter(Collider other)
    {
       
        other.transform.position = exit.position;
        other.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        Physics.SyncTransforms();
        
    }
}
