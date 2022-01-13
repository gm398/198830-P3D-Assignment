using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBBullet : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float impactForce;
    [SerializeField] float minSpeedToImpact = 2f;
    [SerializeField] bool faceMoveDirection = true;
    [SerializeField] Transform tipPoint;
    [SerializeField] LayerMask layers;

    [SerializeField] GameObject spawnOnHit;

    Rigidbody rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        FaceForward();
        CheckForTarget();
    }

    
    private void FixedUpdate()
    {
        FaceForward();
        CheckForTarget();
        
    }

    //fires a raycast between the current position and the next fixedupdate position to detect collisions
    //this is to make sure no target is passed through
    void CheckForTarget()
    {
        Vector3 pointInfront = rb.velocity * 10  + this.transform.position;

        //finds the surface normal of the collider and the direction traveling to check if
        //the object is about to collide at a high enough speed to detonate
        Vector3 surfaceNormalPoint = Physics.ClosestPoint(pointInfront, 
                                                            this.GetComponent<Collider>(),
                                                            this.transform.position,
                                                            this.transform.rotation);
        if (Physics.Raycast(surfaceNormalPoint,
            rb.velocity, out RaycastHit hit,
            rb.velocity.magnitude * Time.fixedDeltaTime,
            layers,
            QueryTriggerInteraction.Ignore) && rb.velocity.magnitude >= minSpeedToImpact)
        {
            BroadcastMessage("TargetHit", hit, SendMessageOptions.DontRequireReceiver);
        }
    }
    void FaceForward()
    {
        if (rb.velocity.magnitude >= minSpeedToImpact && faceMoveDirection)
        {
            transform.LookAt(transform.position + rb.velocity * 2);
        }
    }

    void TargetHit(RaycastHit target)
    {
        if(spawnOnHit != null)
        {
            GameObject spawn = Instantiate(spawnOnHit, target.point, Quaternion.identity);
            spawn.transform.SetParent(null);
        }
        if(target.transform.GetComponent<Health>() != null)
        {
            target.transform.GetComponent<Health>().TakeDamage(damage);
        }
        if (target.transform.GetComponent<Rigidbody>() != null)
        {
            target.transform.GetComponent<Rigidbody>().AddForce(impactForce * rb.velocity.normalized, ForceMode.Impulse);
        }
        Destroy(this.gameObject);
    }
}
