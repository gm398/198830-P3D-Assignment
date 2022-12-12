using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public Transform rotateBarrels;
    public GameObject bullet;
    public float force = 20f;
    public float shotsPerSec = 5;
    public float lineRange = 20f;
    float nextShotTime = 0;
    bool hasShot;
    LineRenderer line;

    bool isShooting;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    public void SetShooting(bool shouldShoot)
    {
        isShooting = shouldShoot;
    }
    public void Shoot()
    {
        if (Physics.Raycast(muzzle.position, muzzle.forward, out RaycastHit hit, lineRange, 1, QueryTriggerInteraction.Ignore))
        {
            line.SetPosition(0, muzzle.position);
            line.SetPosition(1, hit.point);
        }
        else
        {
            line.SetPosition(0, muzzle.position);
            line.SetPosition(1, muzzle.position + muzzle.forward * lineRange);
        }
        if (nextShotTime < Time.time)
        {
            if (isShooting)
            {
                GameObject b = Instantiate(bullet, muzzle.position, muzzle.rotation);
                Rigidbody rb = b.GetComponent<Rigidbody>();
                rb.AddForce(muzzle.forward * force, ForceMode.Impulse);
                Destroy(b, 5);
                nextShotTime = Time.time + 1 / shotsPerSec;
                hasShot = true;
            }
            else
            {
                hasShot = false;
            }
        }
        if (hasShot && rotateBarrels != null)
        {
            rotateBarrels.Rotate(0, 0, 90 * shotsPerSec * Time.deltaTime);
        }
        else if (rotateBarrels != null)
        {
            rotateBarrels.localRotation = Quaternion.identity;
        }
    }
}
