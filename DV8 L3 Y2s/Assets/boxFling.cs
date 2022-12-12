using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxFling : MonoBehaviour
{
    public float force;
    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<Rigidbody>() != null)
        {
            other.GetComponent<Rigidbody>().AddForce(0, force, 0);
        }
    }
}
