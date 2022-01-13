using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] string buttonInput = "e";
    [SerializeField] Animator animator;
    float cooldown = 1f;
    public bool isOpen = false;
    public bool canUse = true;


    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (Input.GetKey(buttonInput) && canUse)
            {
                ActivateDoor();
            }
        }
    }


    void ActivateDoor()
    {
        if (isOpen) { animator.SetTrigger("Close"); isOpen = false; }
        else { animator.SetTrigger("Open"); isOpen = true; }

        canUse = false;
        Invoke("MakeUsable", cooldown);
    }

    void MakeUsable() { canUse = true; }
}
