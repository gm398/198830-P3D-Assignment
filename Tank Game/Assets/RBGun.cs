using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBGun : MonoBehaviour
{
    
    public GameObject projectile;
    public float force = 20f;
    public Transform muzzel;
    public float projectileLifeTime = 5f;

    public float shotsPerSecond = 5f;
    float timeOfNextAttack = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && timeOfNextAttack < Time.time)
        {
            Shoot();
            timeOfNextAttack = Time.time + 1 / shotsPerSecond;
        }
    }

    public void Shoot()
    {
        GameObject p = Instantiate(projectile, muzzel.position, muzzel.rotation);
        Rigidbody rb = p.GetComponent<Rigidbody>();
        rb.AddForce(muzzel.forward * force, ForceMode.Impulse);
        Destroy(p, projectileLifeTime);
    }
}
