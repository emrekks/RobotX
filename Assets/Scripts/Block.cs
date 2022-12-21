using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour, IDamagable
{ 
    public int Health { get; set; }

    [Header("Companent")] 
    public TextMeshPro tmp;
    public Transform weaponPointRef;
    public GameObject[] guns;
    public GunManager[] GunManager;
    public GameManager gm;

    [Space(10)] [Header("Gun Type Settings")] //0 = Ak47// 1 = Pistol// 2 = Rpc 
    public bool ak47;
    public bool pistol;
    public bool rpg;

    private void Start()
    {
        Health = 100;
        
        tmp.text = Health.ToString();
        
        if (ak47)
        {
            Instantiate(guns[0], weaponPointRef);
            guns[0].gameObject.SetActive(true);
        }

        else if (pistol)
        {
            Instantiate(guns[1], weaponPointRef);
            guns[1].gameObject.SetActive(true);
        }
        
        else if (rpg)
        {
            Instantiate(guns[2], weaponPointRef);
            guns[2].gameObject.SetActive(true);
        }
    }

    public void Damage(int amount)
    {
        Health -= amount;
        
        if (Health <= 0)
        {
            Health = 0;

            for (int i = 0; i < gm.playerCloneCount + 1; i++)
            {
                if (ak47)
                {
                    GunManager[i].ChangeWeapon(0);
                }

                else if (pistol)
                {
                    GunManager[i].ChangeWeapon(1);
                }
        
                else if (rpg)
                {
                    GunManager[i].ChangeWeapon(2);
                }
            }

            gameObject.SetActive(false);
        }
        
        tmp.text = Health.ToString();
    }
}
