using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Companent")]
    
    public Transform firePoint;

    public GunData gunData;
    
    private Projectile _projectile;
    
    private EnemyBoss _enemy;
    
    [Space(10)] [Header("Values")]
    
    public int damage;

    public int fireRate;
    
    public bool canFirePlayer;
    
    private float _timeSinceLastShoot;

    [Space(10)] [Header("Bullet Drop To Ground Settings")]
    
    public bool bulletDropActive;

    public GameObject bulletDrop;
    
    public Transform bulletDropPos;


    private void Start()
    {
        damage = gunData.damage;

        fireRate = gunData.fireRate;

        canFirePlayer = true;
        
        _enemy = FindObjectOfType<EnemyBoss>();
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

    
    //If the player's power is higher than 700 and they reach the finish line, this function will activate and the players will be trapped by the boss and start shooting at it.
    public void KillBoss()
    {
        _projectile.targetPos.transform.position = new Vector3(_enemy.transform.position.x, _enemy.transform.position.y + 2, _enemy.transform.position.z);
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
