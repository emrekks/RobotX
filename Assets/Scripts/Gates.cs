using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Gates : MonoBehaviour
{
    [Header("Bonus Type")]
    public BonusTypes bonusTypes;
    
    [Space(10)] [Header("Gun Bonus or Adding Player Amount")]
    public int amount;

    [Space(10)] [Header("Companents")]
    public GameManager gm;
    public GunManager[] gunManager;
    public TextMeshPro tmp;
    public GameObject[] playerClonePrefab;


    [Space(10)] [Header("Gun Type Settings")] //0 = Archtronic// 1 = Mauler// 2 = Hellwailer 
    public bool archtronic;
    public bool mauler;
    public bool hellwailer;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (bonusTypes)
            {
                case BonusTypes.AddPlayer:
                    AddPlayer();
                    break;

                case BonusTypes.DamageBonus:
                    DamageBonusAdd();
                    break;
                
                case BonusTypes.ChangeWeapon:
                    ChangeWeapon();
                    break;
                
                case BonusTypes.FireRateBonus:
                    FireRateBonusAdd();
                    break;
            }
        }
    }

    private void DamageBonusAdd()
    {
        for (int i = 0; i < gm.playerCloneCount + 1; i++)
        {
            if (gunManager[i].isActiveAndEnabled)
            {
                gunManager[i].currentWeapon.GetComponent<Gun>().damage += amount;
            }
        }
    }

    private void FireRateBonusAdd()
    {
        for (int i = 0; i < gm.playerCloneCount + 1; i++)
        {
            if (gunManager[i].isActiveAndEnabled)
            {
                gunManager[i].currentWeapon.GetComponent<Gun>().fireRate += amount;
            }
        }
    }

    private void ChangeWeapon()
    {
        for (int i = 0; i < gm.playerCloneCount + 1; i++)
        {
            if (archtronic)
            {
                gunManager[i].ChangeWeapon(0);
            }

            else if (mauler)
            {
                gunManager[i].ChangeWeapon(1);
            }
        
            else if (hellwailer)
            {
                gunManager[i].ChangeWeapon(2);
            }
        }
    }

    private void AddPlayer()
    {
        for (int i = 0; i < amount; i++)
        {
            if (gm.playerCloneCount == 0)
            {
                playerClonePrefab[0].SetActive(true);
            }
            else if (gm.playerCloneCount != 0)
            {
                playerClonePrefab[1].SetActive(true);
            }
            gm.playerCloneCount++;
        }
    }
}

public enum BonusTypes
{
    AddPlayer,
    ChangeWeapon,
    DamageBonus,
    FireRateBonus
}