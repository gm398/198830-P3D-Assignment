using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    //can this item be icked up?
    [SerializeField] bool usable;
    [SerializeField] bool currentlyHeld;

    //offset relative to the hold point, useful to make object look better in first person
    [SerializeField] Vector3 holdOffset;

    //different components to be enabled/disabled when the item is picked up or dropped
    [SerializeField] private MonoBehaviour[] toggledScripts;

    [SerializeField] Rigidbody rb;
    [SerializeField] Collider itemCollider;
    [SerializeField] private MonoBehaviour[] activateWhenDropped;

    private void Awake()
    {
        //EnableItem(currentlyHeld);
        if (rb == null) { rb = this.GetComponent<Rigidbody>(); }
        if (itemCollider == null) { itemCollider = this.GetComponent<Collider>(); }
    }
    public void EnableItem(bool onOff)
    {
        foreach (MonoBehaviour c in toggledScripts)
        {
            c.enabled = onOff;
        }
        foreach (MonoBehaviour c in activateWhenDropped)
        {
            c.enabled = !onOff;
        }
        rb.isKinematic = onOff;
        itemCollider.enabled = !onOff;
    }

    public bool IsUsable()
    {
        return usable;
    }
    public Vector3 GetHoldOffset() { return holdOffset; }

  
    /*
    public void SetAttackPoint(Transform attackPoint)
    {
        this.attackPoint = attackPoint;
        item.SendMessage("SetAttackPoint", attackPoint, SendMessageOptions.DontRequireReceiver);
    }
    */
}
