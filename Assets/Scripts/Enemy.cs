using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Transform turretMovingPart;
    public float enemyPerceiveDistance;
    private float _distanceBetweenToObject;
    private bool doOnce;
    private float random;

    public Transform firePoint;
    private TurretAmmo _turretAmmo;
    private float _timeSinceLastShoot;
    public int fireRate; 
    public int damage; 
    
    private bool CanShoot() => _timeSinceLastShoot > 1f / (fireRate / 60);
    
    
    public void Shoot()
    {
        if (CanShoot())
        {
            var muzzle = ObjectPooling.instance.GetMuzzleFromPool();

            muzzle.transform.position = firePoint.position;

            muzzle.SetActive(true);

            _turretAmmo = ObjectPooling.instance.GetTurretAmmoFromPool();
            
            _turretAmmo.transform.position = firePoint.position;

            _turretAmmo.damage = damage;
            
            _turretAmmo.gameObject.SetActive(true);
            
            _timeSinceLastShoot = 0;

            doOnce = false;
        }
    }

    void Update()
    {
        _distanceBetweenToObject = Vector3.Distance(player.position, transform.position);

        if (_distanceBetweenToObject <= enemyPerceiveDistance)
        {
            if (!doOnce)
            {
                random = Random.Range(-10.0f, 10.0f);
                doOnce = true;
            }
            turretMovingPart.LookAt(player);
            turretMovingPart.transform.Rotate(-90,0,random);
            _timeSinceLastShoot += Time.deltaTime;
            Shoot();
        }
    }
}
