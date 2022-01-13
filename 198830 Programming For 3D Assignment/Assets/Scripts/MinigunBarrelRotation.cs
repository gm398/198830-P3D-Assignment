using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunBarrelRotation : MonoBehaviour
{
    [SerializeField] GameObject barrel;
    GunController controller;


    private void Awake()
    {
        if (transform.GetComponent<GunController>() != null)
        {
            controller = transform.GetComponent<GunController>();
        }
    }
    private void Update()
    {
        if (!controller.GetCanShoot()) { RotateBarrel(); }
    }
    void Shoot()
    {
        RotateBarrel();
    }
    void OutOfAmmo()
    {
        RotateBarrel();
    }


    void RotateBarrel()
    {
        barrel.transform.Rotate(0, 0, 45 * Time.deltaTime * controller.GetAttacksPerSecond());
    }


}
