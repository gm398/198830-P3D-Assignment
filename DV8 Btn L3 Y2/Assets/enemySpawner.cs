using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public int units = 0;
    public GameObject unit;
    public float unitsPerSec = .2f;
    float nextUnitTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        units = 0;
        if(unitsPerSec == 0)
        {
            unitsPerSec = 0.001f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(nextUnitTime < Time.time)
        {
            Instantiate(unit, this.transform.position, this.transform.rotation).transform.SetParent(this.transform);
            nextUnitTime = Time.time + 1 / unitsPerSec;
            units++;
        }
    }
}
