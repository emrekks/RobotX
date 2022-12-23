using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDamagable
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    public int Health { get; set; }
    public TextMeshPro tmp;

    private void Start()
    {
        Health = 100;
        
        tmp.text = Health.ToString();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(horizontal, 0, 1);
        rb.velocity = move * speed;
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
}
