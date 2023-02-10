using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAmmo : MonoBehaviour
{
    public Rigidbody rb;
    public TrailRenderer trailRenderer;
    [SerializeField] private float speed = 2;
    [HideInInspector]public int damage;

    private void OnEnable()
    {
        trailRenderer.Clear();
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        StartCoroutine(DisableTurretAmmo());
    }

    IEnumerator DisableTurretAmmo()
    {
        yield return new WaitForSeconds(2f);
        ObjectPooling.instance.GetTurretAmmoBackToPool(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3)
        {
            ObjectPooling.instance.GetTurretAmmoBackToPool(this);
            
            if(other.TryGetComponent(out IDamagable hit))
            {
                hit.Damage(damage);
            }
        }
    }
}
