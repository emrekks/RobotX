using System;
using DG.Tweening;
using UnityEngine;


public class EnemyBoss : MonoBehaviour, IDamagable
{
    public GameObject jumpRef;
    
    public Movement player;
   
    public Animator anim;

    public GameObject slashVfx;

    public int health = 100;

    public bool finishline = false;
    
    public int Health { get; set; }

    private void Start()
    {
        Health = health;
    }

    public void Jump()
    {
        transform.DOLookAt(jumpRef.transform.position, 0.1f).OnComplete(()=> anim.SetTrigger("Attack"));
    } 

    public void Move()
    {
        transform.DOJump(jumpRef.transform.position, 3, 1, 0.90f);
    }

    public void LookAtCharacter()
    {
        transform.DOLookAt(player.transform.position, 0.1f, AxisConstraint.Y);
    }

    public void AttackSlashVfx()
    {
        Instantiate(slashVfx, transform);
    }
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
