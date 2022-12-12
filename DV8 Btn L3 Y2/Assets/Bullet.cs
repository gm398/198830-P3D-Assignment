using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    public GameObject explosion;
    public GameObject trail;
    public float explosionRadius = 1f;


    private void OnTriggerEnter(Collider other)
    {
        

        if (explosion == null)
        {
            Health h = other.GetComponent<Health>();
            if (h != null)
            {
                h.TankeDamage(damage);
            }
        }
        else
        {
            GameObject e = Instantiate(explosion, transform.position, transform.rotation);
            e.transform.localScale = new Vector3(explosionRadius, explosionRadius, explosionRadius);
            Destroy(e, 2);
            foreach (Collider c in Physics.OverlapSphere(transform.position, explosionRadius))
            {
                Health h = c.GetComponent<Health>();
                if(h != null)
                {
                    h.TankeDamage(damage);
                }
            }
        }
        if (trail != null)
        {
            trail.transform.parent = null;
            trail.GetComponent<ParticleSystem>().Stop();
            Destroy(trail, 5);
        }
            Destroy(this.gameObject);
    }
}
