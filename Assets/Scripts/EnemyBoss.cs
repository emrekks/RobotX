using System;
using DG.Tweening;
using UnityEngine;


public class EnemyBoss : MonoBehaviour, IDamagable
{
    [Header("Companent")]
    
    [Tooltip("The transform of the position where the boss will jump.")]
    public Transform jumpRef;
    
    [Tooltip("Assign the 'PlayerManager' inside to allow the boss to target players.")]
    public GameObject player;
   
    public Animator anim;
   
    [Tooltip("Assign the boss's attack slash VFX here.(Red claw)")]
    public GameObject slashVfx;
    
    
    [Header("Stats")] 
    
    [Tooltip("Sets the player's health.")]
    public int health = 100;
    
    [Tooltip("The place where the player will stop at the end of the game.")]
    public bool finishline = false;
    
    //IDamageable properties
    public int Health { get; set; }

    private void Start()
    {
        Health = health;
    }

    //Boss jumps anim started.
    public void Jump()
    {
        transform.DOLookAt(jumpRef.position, 0.1f).OnComplete(()=> anim.SetTrigger("Attack"));
    } 

    //Boss starts moving towards the player.
    public void Move()
    {
        transform.DOJump(jumpRef.position, 3, 1, 0.90f);
    }

    //Boss looking player.
    public void LookAtCharacter()
    {
        transform.DOLookAt(player.transform.position, 0.1f, AxisConstraint.Y);
    }

    //Boss starts to attack player.
    public void AttackSlashVfx()
    {
        Instantiate(slashVfx, transform);
    }
    
    //Function of the IDamageable interface. Works when the enemy is damaged.
    public void Damage(int amount)
    {
        if (finishline)
        {
            health -= amount;
        
            if (health <= 0)
            {
                health = 0;

                anim.SetTrigger("Death");
            } 
        }
    }
}
