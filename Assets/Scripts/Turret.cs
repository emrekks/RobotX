using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Turret : MonoBehaviour
{
    public Transform[] playerTransforms;
    public Transform closestPlayer;
    public Transform turretMovingPart;
    public float enemyPerceiveDistance;
    private float _distanceBetweenToObject;
    private float minDistance = Mathf.Infinity;

    public Transform firePoint;
    private TurretAmmo _turretAmmo;
    private float _timeSinceLastShoot;
    public int fireRate; 
    public int damage;
    private int random;
    
    private bool CanShoot() => _timeSinceLastShoot > 1f / (fireRate / 60);

    public void Shoot()
    {
        if (CanShoot())
        {
            random = Random.Range(0, 15);
            
            var muzzle = ObjectPooling.instance.GetMuzzleFromPool();

            muzzle.transform.position = firePoint.position;

            muzzle.SetActive(true);

            _turretAmmo = ObjectPooling.instance.GetTurretAmmoFromPool();
            
            _turretAmmo.transform.position = firePoint.position;

            _turretAmmo.transform.eulerAngles = firePoint.eulerAngles;

            _turretAmmo.damage = damage;
            
            _turretAmmo.gameObject.SetActive(true);
            
            _timeSinceLastShoot = 0;
        }
    }

    void Update()
    {
        _distanceBetweenToObject = Vector3.Distance(closestPlayer.position, transform.position);

        if (_distanceBetweenToObject <= enemyPerceiveDistance)
        {
            foreach (var playerTransform in playerTransforms)
            {
                if (playerTransform.gameObject.activeInHierarchy)
                {
                    float distance = Vector3.Distance(playerTransform.position, transform.position);
                
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestPlayer = playerTransform;
                    }  
                }
            }

            turretMovingPart.LookAt(closestPlayer);
           
            turretMovingPart.transform.Rotate(-90,0,random);
           
            _timeSinceLastShoot += Time.deltaTime;
          
            Shoot();
        }
    }
}
