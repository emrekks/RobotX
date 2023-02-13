using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Companent")]
    
    public Rigidbody rb;
    
    [Tooltip("Reference of where the bullets will go.")]
    public GameObject targetPos;
    
    public TrailRenderer trailRenderer;
    
    [SerializeField] private float speed = 2;
    
    [HideInInspector]public int damage;
    
    
    private void OnEnable()
    {
        trailRenderer.Clear();
        targetPos = GameObject.FindGameObjectWithTag("FireRefPos");
        rb.AddForce((targetPos.transform.position - transform.position) * speed, ForceMode.VelocityChange);
        StartCoroutine(DisableProjectile());
    }

    IEnumerator DisableProjectile()
    {
        yield return new WaitForSeconds(0.75f);
        ObjectPooling.instance.GetProjectileBackToPool(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IDamagable hit))
        {
            ObjectPooling.instance.GetProjectileBackToPool(this);

            hit.Damage(damage);
        }
    }
}
