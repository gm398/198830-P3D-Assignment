using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    //inputs
    [SerializeField] string buttonInput = "mouse 0";
    [SerializeField] string reloadIput = "r";
    [SerializeField] bool allowButtonHold;
    bool shooting, canShoot;

    //weapon stats
    [SerializeField] float attacksPerSecond = 2f;

    //
    [SerializeField] LayerMask layers;

    //amunition managment
    [SerializeField] float maxAmmo = 20f;
    [SerializeField] float currentAmmo;
    [SerializeField] float reloadTime = 1f;
    bool isReloading;


    //important transforms
    [SerializeField] Transform hitscanPoint, attackPoint;

    
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputs();
        ChooseAction();
    }

    void PlayerInputs()
    {
        
        if (allowButtonHold) { shooting = Input.GetKey(buttonInput); }
        else { shooting = Input.GetKeyDown(buttonInput); }
        
        if(Input.GetKey(reloadIput) 
            && currentAmmo < maxAmmo 
            && !isReloading) {
            BroadcastMessage("Reload", SendMessageOptions.DontRequireReceiver);
        }
        
    }
    void ChooseAction()
    {
        
        if (isReloading) {
            return;
        }
        if (shooting && canShoot && currentAmmo > 0)
        {
            BroadcastMessage("Shoot", SendMessageOptions.DontRequireReceiver);
        }
        if(shooting && currentAmmo <= 0)
        {
            BroadcastMessage("OutOfAmmo", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void Shoot()
    {
        canShoot = false;
        currentAmmo--;
        Invoke("ResetShot", 1 / attacksPerSecond);
    }

  

    void ResetShot()
    {
        canShoot = true;
    }
    void Reload()
    {
        isReloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    void ReloadFinished()
    {
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    public void SetHitscanPoint(Transform point)
    {
        hitscanPoint = point;
    }

    public float GetAttacksPerSecond() { return attacksPerSecond; }
    public bool GetCanShoot() { return canShoot; }
    public Transform GetHitscanPoint() { return hitscanPoint; }
    public Transform GetAttackPoint() { return attackPoint; }
    public LayerMask GetLayers() { return layers; }
    public float GetReloadTime() { return reloadTime; }
}
