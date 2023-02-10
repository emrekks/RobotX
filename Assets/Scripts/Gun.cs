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

    [Space(10)] [Header("Bullet Drop To Ground Settings")]
    
    public bool bulletDropActive;

    public GameObject bulletDrop;
    
    public Transform bulletDropPos;

    public bool canFirePlayer;

    private EnemyBoss enemy;
 


    private void Start()
    {
        damage = gunData.damage;

        fireRate = gunData.fireRate;

        canFirePlayer = true;
        
        enemy = FindObjectOfType<EnemyBoss>();
    }

    private bool CanShoot() => _timeSinceLastShoot > 1f / (fireRate / 60) && canFirePlayer;
    
    
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

            if (bulletDropActive)
            {
                Instantiate(bulletDrop, bulletDropPos);
            }
        }
    }

    public void KillBoss()
    {
        _projectile.targetPos.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 2, enemy.transform.position.z);
        StartCoroutine(WaitForFunction());
    }
    
    IEnumerator WaitForFunction()
    { 
        yield return new WaitForSeconds(1f);
        canFirePlayer = true;
        yield return new WaitForSeconds(2f);
        canFirePlayer = false;
    }

    void Update()
    {
        _timeSinceLastShoot += Time.deltaTime;
        
        Shoot();
    }
}
