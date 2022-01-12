using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSounds : MonoBehaviour
{


    [SerializeField] AudioSource shot1;
    [SerializeField] AudioSource OOAmmo;
 
    public void GunFire()
    {
        shot1.Play();
    }
    public void OutOfAmmo()
    {
        OOAmmo.Play();
    }
}
