using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    public int Health { get; set; }
    public TextMeshPro tmp;
    public Animator anim;
    public GunManager gunManager;

    private void OnEnable()
    {
        tmp.gameObject.SetActive(true);
    }

    private void Start()
    {
        Health = 100;
        
        tmp.text = Health.ToString();
    }

    public void Damage(int amount)
    {
        Health -= amount;
        
        if (Health <= 0)
        {
            Health = 0;

            gameObject.SetActive(false);
        }
        
        tmp.text = Health.ToString();
    }

    public void ChangeAnimation()
    {
        anim.SetBool("Idle", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EnemyHandToAttack"))
        {
            Health = 0;
            tmp.text = Health.ToString();
            anim.SetTrigger("Die");
        }
    }
}
