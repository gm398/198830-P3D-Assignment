using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] string buttonInput = "e";
    [SerializeField] GameObject item;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float cooldown = 2f;
    bool canUse = true;
    

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (Input.GetKey(buttonInput) && canUse)
            {
                SpawnItem();
            }
        }
    }

    void SpawnItem()
    {
        GameObject newItem = Instantiate(item, spawnPoint);
        newItem.transform.parent = null;

        canUse = false;
        Invoke("ResetCanUse", cooldown);
    }

    void ResetCanUse()
    {
        canUse = true;
    }
}
