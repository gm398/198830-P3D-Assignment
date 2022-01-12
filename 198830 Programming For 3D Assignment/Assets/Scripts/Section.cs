using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    public Section[] children;
    public Section parent;

    public GameObject model;
    public float deathDelay = 1;
    bool isSectionDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }
    
    public void Die()
    {
        foreach (Section child in children)
        {
            if (child != null)
            {
                child.DieAfterTime(deathDelay);
            }
        }
        isSectionDead = true;
        DeactivateModel();
        
    }
    public void DieAfterTime(float timeTilDie)
    {
        foreach (Section child in children)
        {
            if (child != null)
            {
                child.DieAfterTime(timeTilDie + deathDelay);
            }
        }
        isSectionDead = true;
        Invoke("DeactivateModel", timeTilDie);
    }

    public bool isDead() { return isSectionDead; }
    void DeactivateModel()
    {
        this.gameObject.AddComponent<Rigidbody>();
        this.transform.SetParent(null);
        this.GetComponent<Collider>().enabled = false;
        Destroy(this.gameObject, 5);
    }
}
