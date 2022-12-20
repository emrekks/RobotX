using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunData gunData;
    
    private float _timeSinceLastShoot;

    public Transform firePoint;
    
    private Projectile _projectile;
    
    private bool CanShoot() => _timeSinceLastShoot > 1f / (gunData.fireRate / 60);
    
    
    public void Shoot()
    {
        if (CanShoot())
        {
            _projectile = ObjectPooling.instance.GetProjectileFromPool();
            
            _projectile.transform.position = firePoint.position;

            _projectile.damage = gunData.damage;
            
            _projectile.gameObject.SetActive(true);
            
            _timeSinceLastShoot = 0;
        }
    }

    
    void Update()
    {
        _timeSinceLastShoot += Time.deltaTime;
        
        Shoot();
    }
}
