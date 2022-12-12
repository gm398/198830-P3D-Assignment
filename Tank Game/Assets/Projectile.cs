using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject spawnOnHit;
    public float damage = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (spawnOnHit != null)
        {
            Destroy(Instantiate(spawnOnHit, transform.position, transform.rotation), 2);
        }
        Destroy(gameObject);
    }
}
