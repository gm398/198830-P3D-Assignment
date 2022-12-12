using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public Transform target, target2;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 avr = (target.position + target2.position) / 2;
        float height = Vector3.Distance(target.position, target2.position);
        Vector3 pos = avr + offset;
        pos.y = pos.y + height;
        
        this.transform.position = pos;
    }
}
