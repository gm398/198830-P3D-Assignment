using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch : MonoBehaviour
{
    public float force = 10;
   

    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(0, force, 0);
    }
}
