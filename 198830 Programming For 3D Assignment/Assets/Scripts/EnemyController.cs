using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float speed = 10;
    [SerializeField] float damage = 5;
    [SerializeField] GameObject explosion;
    [SerializeField] bool explodes = false;
    [SerializeField] CharacterController controller;
    private int counter;

    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        agent.destination = target.transform.position;

        /*
        counter++;
        if (counter > 2)
        {
            transform.LookAt(target.transform);
            controller.Move(transform.forward * speed * counter * Time.deltaTime);
            counter = 0;
        }
        */
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Die();
        }
    }
    
    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    void Explode()
    {
        GameObject explo = Instantiate(explosion, transform.position, transform.rotation);
        explo.GetComponent<Explosion>().SetDamage(damage);
        Destroy(explo, .2f);
    }

    void Die()
    {
        if (explodes)
        {
            Explode();
        }
        Destroy(this.gameObject, .1f);
    }
}
