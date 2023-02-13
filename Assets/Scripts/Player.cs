using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    [Header("Companent")]
    
    [Tooltip("This text mesh for player health on player.")]
    public TextMeshPro tmp;
  
    [Tooltip("Assign player animator.")]
    public Animator anim;
    
    [Tooltip("Assign players' gun manager.")]
    public GunManager gunManager;
    
    public int Health { get; set; }

    //When player setactive true, health text is setactive true
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

            anim.SetTrigger("Die");
        }
        
        tmp.text = Health.ToString();
    }

    public void ChangeAnimation()
    {
        anim.SetBool("Idle", true);
    }

    
    // The boss's hand kills the player if it touches the player.
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
