using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private string buttonInput = "f";
    [SerializeField] private float throwForce = 100f;
    [SerializeField] private float upForce = 10f;

    //time between pickups to avoid unwanted grabbing
    [SerializeField] private float interactCooldown = .5f;
    private float timeOfNextInteract = 0f;

    //interaction sphere details range
    [SerializeField] private float pickupRange = 2f;
    [SerializeField] private float pickupRadius = 1f;

    //key transforms to be potentially used by the picked up object
    [SerializeField] private Transform holdPoint;
    [SerializeField] private Transform hitscanPoint;

    
    [SerializeField] private bool isHolding;

    //the object being picked up
    [SerializeField] private GameObject heldItem;
    private PickupItem heldItemDetails;




    private void Start()
    {
        if (isHolding 
            && heldItem != null)
        {
            HoldItem(heldItem);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //checks for input then attempts to pick up or throw an item
        if (Input.GetKey(buttonInput) && timeOfNextInteract <= Time.time){
            if (isHolding)
            {
                ThrowItem();
            }
            else { PickupItem(); }

            
        }
    }

    //item is picked up and is enabled
    void HoldItem(GameObject item)
    {
        if (item.GetComponent<PickupItem>() == null) { return; }
        PickupItem details = item.GetComponent<PickupItem>();
        if (!details.IsUsable()) { return; }

        heldItem = item;
        heldItemDetails = details;
        details.EnableItem(true);
        isHolding = true;

        heldItem.transform.SetParent(holdPoint);
        heldItem.transform.position = holdPoint.position;
        heldItem.transform.localPosition += heldItemDetails.GetHoldOffset(); ;
        heldItem.transform.rotation = holdPoint.rotation;

        //gives the point from where hitscan lines are generated to the item if neededS
        heldItem.BroadcastMessage("SetHitscanPoint", hitscanPoint, SendMessageOptions.DontRequireReceiver);

        timeOfNextInteract = Time.time + interactCooldown;
    }


    //if an item that can be picked up is in range and no item is currently held, pick it up
    public void PickupItem()
    {
        Collider[] hits = Physics.OverlapSphere(hitscanPoint.position + hitscanPoint.forward * pickupRange, pickupRadius);
        foreach(Collider hit in hits)
        {
            if (!isHolding)
            {
                HoldItem(hit.gameObject);
            }
        }
    }

    // de-parents the currently held item and adds force to it
    public void ThrowItem()
    {
        heldItem.transform.SetParent(null);
        heldItemDetails.EnableItem(false);

        Rigidbody rb = heldItem.GetComponent<Rigidbody>();
        if (rb.mass < .5)
        {
            rb.AddForce(throwForce * 2 * rb.mass * holdPoint.forward, ForceMode.Impulse);
            rb.AddForce(upForce * 2 * rb.mass * holdPoint.up, ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(throwForce * holdPoint.forward, ForceMode.Impulse);
            rb.AddForce(upForce * holdPoint.up, ForceMode.Impulse);
        }

        if(this.GetComponent<CharacterController>() != null)
        {
            CharacterController c = this.GetComponent<CharacterController>();
            rb.AddForce(c.velocity * rb.mass, ForceMode.Impulse);
        }
        

        heldItem = null;
        heldItemDetails = null;
        isHolding = false;

        timeOfNextInteract = Time.time + interactCooldown;
    }

    //toggles different parts of the object on or off depending if it is being picked up or dropped
   


    //shows the pickup range in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(hitscanPoint.position + hitscanPoint.forward * pickupRange, pickupRadius);
        
    }

}
