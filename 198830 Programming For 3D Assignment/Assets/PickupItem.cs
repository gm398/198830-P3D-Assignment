using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    //can this item be icked up?
    [SerializeField] bool usable;

    //different components to be enabled/disabled when the item is picked up or dropped
    [SerializeField] private MonoBehaviour[] toggledScripts;

    [SerializeField] Rigidbody rb;
    [SerializeField] Collider itemCollider;

    public void EnableItem(bool onOff)
    {
        foreach (MonoBehaviour c in toggledScripts)
        {
            c.enabled = onOff;
        }
        rb.isKinematic = onOff;
        itemCollider.enabled = !onOff;
    }

    public bool IsUsable()
    {
        return usable;
    }

  
    /*
    public void SetAttackPoint(Transform attackPoint)
    {
        this.attackPoint = attackPoint;
        item.SendMessage("SetAttackPoint", attackPoint, SendMessageOptions.DontRequireReceiver);
    }
    */
}
