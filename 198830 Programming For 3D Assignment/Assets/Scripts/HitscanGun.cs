using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitscanGun : MonoBehaviour
{
    [SerializeField] string buttonInput = "mouse 0";
    [SerializeField] string zoomInput = "mouse 1";
    [SerializeField] string reloadIput = "r";

    [SerializeField] float attacksPerSecond = 2f;
    private float nextAttackTime = 0f;
    
    [SerializeField] float damage = 10f;
    [SerializeField] float bulletForce = 100f;
    [SerializeField] LayerMask layers;
    [SerializeField] float range = 100f;

    [SerializeField] float maxSpread = 1f;
    [SerializeField] float maxZoomSpread = .5f;
    [SerializeField] float minSpread = 0f;
    [SerializeField] float spreadSpeed = 10f;
    public float currentSpread = 0f;
    bool zoomed;

    [SerializeField] float spreadLerpSpeed = 20;
    [SerializeField] float spreadLerpSpeed2 = 5;
    [SerializeField] Transform hitscanPoint;
    [SerializeField] Transform gunBarrelPoint;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] GameObject barrel;
    private float t = 1f;

    [SerializeField] private float ammo = 100;
    private float maxAmmo;
    private bool reloading = false;
    [SerializeField] float reloadTime = 2;
    private float reloadTimer = 0;
    [SerializeField] Text ammoCounter;
    

    [SerializeField] LineRenderer bulletTrail;
    [SerializeField] GameObject hitMarker;

    
    [SerializeField] GameObject ammoType;


    private bool hasShot;

    private void Start()
    {
        maxAmmo = ammo;
    }
    private void Awake()
    {
        currentSpread = minSpread;
    }
    // Update is called once per frame
    void Update()
    {
        hasShot = false;
        zoomed = Input.GetKey(zoomInput);
        
        if (Input.GetKey(reloadIput))
        {
            reloading = true;
            ammoCounter.text = "Loading";
        }
        if (Time.time >= nextAttackTime && !reloading)
        {
            ammoCounter.text = "" + ammo;
            if (Input.GetKey(buttonInput))
            {
                if (ammo > 0)
                {
                    Shoot();
                    ammo--;

                }
                else { SendMessage("OutOfAmmo", SendMessageOptions.DontRequireReceiver); }
                hasShot = true;
                nextAttackTime = Time.time + 1f / attacksPerSecond;
                t = 0;

            }
            if(ammo <= 0) { ammoCounter.text = "Press " + "'" + reloadIput + "'"; }

        }
       
        if (t <= 1f / attacksPerSecond)
        {
            barrel.transform.Rotate(0, 0, 45 * Time.deltaTime * attacksPerSecond);
        }
        t += Time.deltaTime;
        
        if (reloading)
        {
            reloadTimer += Time.deltaTime;
            if (reloadTimer >= reloadTime) { Reload(); }
        }
        if (!hasShot)
        {
           // transform.rotation = Quaternion.Lerp(transform.rotation, attackPoint.rotation, spreadLerpSpeed/attacksPerSecond * Time.deltaTime);
            currentSpread -= spreadSpeed/attacksPerSecond * 2 * Time.deltaTime;
            if(currentSpread <= minSpread) { currentSpread = minSpread; }
        }

        Quaternion q = hitscanPoint.transform.rotation;
        
        Vector3 targetVec = hitscanPoint.position + hitscanPoint.forward * range;

        if(Physics.Raycast(hitscanPoint.position, hitscanPoint.forward, out RaycastHit hit, range, layers, QueryTriggerInteraction.Ignore))
        {
            targetVec = hit.point;
        }
        q.SetLookRotation(targetVec - transform.position, hitscanPoint.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, q, 5 * Time.deltaTime);
        
    }

    public void Shoot()
    {
        SendMessage("GunFire", SendMessageOptions.DontRequireReceiver);
        Quaternion bulletSpread = Quaternion.Euler(Random.Range(-currentSpread, currentSpread),Random.Range(-currentSpread, currentSpread), Random.Range(-currentSpread, currentSpread));

        transform.rotation = Quaternion.Lerp(transform.rotation, bulletSpread * gunBarrelPoint.rotation, spreadLerpSpeed * Time.deltaTime);
        currentSpread += spreadSpeed * Time.deltaTime;
        if (zoomed) { if (currentSpread > maxZoomSpread) { currentSpread = maxZoomSpread; } }
        else { if (currentSpread > maxSpread) { currentSpread = maxSpread; } }


        if (Physics.Raycast(gunBarrelPoint.position, bulletSpread * gunBarrelPoint.forward, out RaycastHit hit, range, layers, QueryTriggerInteraction.Ignore))
        {
            
            Debug.Log("hit: " + hit.transform.name);
                
            if (hit.transform.GetComponent<Health>() != null)
            {
                Debug.Log("damaged: " + hit.transform.name);
                hit.transform.GetComponent<Health>().TakeDamage(damage);

            }
            if(hit.transform.GetComponent<Rigidbody>() != null)
            {
                hit.transform.GetComponent<Rigidbody>().AddForceAtPosition(gunBarrelPoint.forward * bulletForce, hit.point);
            }

            SpawnBulletTrail(hit.point);
            GameObject bulletHitPoint = Instantiate(hitMarker, hit.point, Quaternion.identity);
            bulletHitPoint.transform.parent = hit.transform;
            Destroy(bulletHitPoint, 5f);
        }
        else
        {
            SpawnBulletTrail(hitscanPoint.position + bulletSpread * hitscanPoint.forward * range);
        }
      
    }

    void ShootProjectile()
    {
        GameObject bullet = Instantiate(ammoType, gunBarrelPoint.position, gunBarrelPoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(gunBarrelPoint.forward * 3000);
    }

    private void SpawnBulletTrail(Vector3 hitPoint)
    {
        GameObject bulletTrailEffect = Instantiate(bulletTrail.gameObject, gunBarrelPoint.position, Quaternion.identity);

        LineRenderer lineR = bulletTrailEffect.GetComponent<LineRenderer>();
        lineR.SetPosition(0, gunBarrelPoint.position);
        lineR.SetPosition(1, hitPoint);
        Destroy(bulletTrailEffect, 1f);

        
    }

    private void Reload()
    {
        ammo = maxAmmo;
        currentSpread = minSpread;
        reloading = false;
        reloadTimer = 0;
    }

    public float GetAmmo() { return ammo; }

    public void SetHitscanPoint(Transform point)
    {
        hitscanPoint = point;
    }

    private void OnDrawGizmosSelected()
    {
        if (hitscanPoint == null) { return; }
        RaycastHit hit;
        if (Physics.Raycast(gunBarrelPoint.position, gunBarrelPoint.forward, out hit, range))
        {
            Gizmos.color = Color.red;
        }
        else { Gizmos.color = Color.blue; }
        Gizmos.DrawRay(gunBarrelPoint.position, gunBarrelPoint.forward * range);
    }
}