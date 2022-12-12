using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float range = 20;
    public float rotateSpeed;
    Transform target;
    public Transform turretBall;
    public Transform turret;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(target.position, transform.position) > range)
            { target = null; }
        }
        if(target == null)
        {
            foreach (Collider t in Physics.OverlapSphere(this.transform.position, range))
            {
                Health h = t.GetComponent<Health>();
                if (h != null)
                {
                    target = h.transform;
                }
            }
        }
        if(target != null)
        {
            turretBall.LookAt(target.position);
            Vector3 tr = turretBall.rotation.eulerAngles;
            tr.x = 0;
            tr.z = 0;
            turret.rotation = Quaternion.Euler(tr);
            BroadcastMessage("SetShooting", true, SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            BroadcastMessage("SetShooting", false, SendMessageOptions.DontRequireReceiver);
            turret.Rotate(0, rotateSpeed * Time.deltaTime, 0);
            turretBall.rotation = turret.rotation;
        }

        


    }
}
