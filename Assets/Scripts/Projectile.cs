using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    
    [SerializeField] private float speed = 2;

    public int damage;
    
    private void OnEnable()
    {
        rb.AddForce(Vector3.back * speed, ForceMode.VelocityChange);
        StartCoroutine(DisableProjectile());
    }

    IEnumerator DisableProjectile()
    {
        yield return new WaitForSeconds(2f);
        ObjectPooling.instance.GetProjectileBackToPool(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Block"))
        {
            ObjectPooling.instance.GetProjectileBackToPool(this);
            
            if(other.TryGetComponent(out IDamagable hit))
            {
                hit.Damage(damage);
            }
        }
    }
}
