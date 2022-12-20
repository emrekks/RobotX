using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour, IDamagable
{
    public int Health { get; set; }

    public TextMeshPro tmp;

    private void Start()
    {
        Health = 100;
        tmp.text = Health.ToString();
    }

    public void Damage(int amount)
    {
        Health -= amount;
        tmp.text = Health.ToString();
    }
}
