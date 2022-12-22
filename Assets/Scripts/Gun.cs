using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class Gun : MonoBehaviour
{
    public GunData gunData;

    public int damage;

    public int fireRate;
    
    private float _timeSinceLastShoot;

    public Transform firePoint;
    
    private Projectile _projectile;

    public GameObject bulletDrop;
    
    public Transform bulletDropPos;


    private void Start()
    {
        damage = gunData.damage;

        fireRate = gunData.fireRate;
    }

    private bool CanShoot() => _timeSinceLastShoot > 1f / (fireRate / 60);
    
    
    public void Shoot()
    {
        if (CanShoot())
        {
            var muzzle = ObjectPooling.instance.GetMuzzleFromPool();

            muzzle.transform.position = firePoint.position;

            muzzle.SetActive(true);

            _projectile = ObjectPooling.instance.GetProjectileFromPool();
            
            _projectile.transform.position = firePoint.position;

            _projectile.damage = damage;
            
            _projectile.gameObject.SetActive(true);
            
            _timeSinceLastShoot = 0;

            Instantiate(bulletDrop, bulletDropPos);
        }
    }

    void Update()
    {
        _timeSinceLastShoot += Time.deltaTime;
        
        Shoot();
    }
}
