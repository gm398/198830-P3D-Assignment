using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    [SerializeField] float damage = 5;
    [SerializeField] float radius = .5f;
    [SerializeField] float lifetime = 1f;
    [SerializeField] float pushForce = 100f;
    [SerializeField] float upForce = 5f;
    [SerializeField] ParticleSystem particles;

    private void Awake()
    {
        if (particles != null)
        {
            particles.transform.localScale = new Vector3(2 * radius, 2 * radius, 2 * radius);
        }
        DetectTargets();
        Destroy(this.gameObject, lifetime);
    }

    private void DetectTargets()
    {
        Collider[] targets = Physics.OverlapSphere(this.transform.position, radius);
        foreach(Collider c in targets)
        {
            if(c.GetComponent<Rigidbody>() != null)
            {
                //c.GetComponent<Rigidbody>().AddForce(pushForce * (c.transform.position - transform.position).normalized);
                c.GetComponent<Rigidbody>().AddExplosionForce(pushForce, transform.position, radius, upForce, ForceMode.Impulse);
            }
            if(c.GetComponent< Health>() != null)
            {
                Damage(c);
            }
        }
    }

    private void Damage(Collider other)
    {
        if (other.gameObject.GetComponent<Health>() != null)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
