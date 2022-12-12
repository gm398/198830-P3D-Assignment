using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public Transform barrel;
    public float force;
    public float rps;
    public Transform rotateBarrel;
    bool hasShot;
    float nextShotTime = 0;
    // Update is called once per frame
    void Update()
    {
        if (nextShotTime < Time.time)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                hasShot = true;
                GameObject b = Instantiate(bullet, barrel.position, barrel.rotation);
                b.transform.localScale = transform.localScale;
                Rigidbody rb = b.GetComponent<Rigidbody>();
                rb.AddForce(this.transform.forward * force, ForceMode.Impulse);
                nextShotTime = Time.time + (1 / rps);
            }
            else
            {
                hasShot = false;
                rotateBarrel.localRotation = Quaternion.identity;
            }
           
        }
        if (hasShot)
        {

            rotateBarrel.Rotate(0, 0, 45 * rps * Time.deltaTime);
        }
    }
}
