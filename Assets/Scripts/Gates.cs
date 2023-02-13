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

            StartCoroutine(AfterGateCheckPowerDelay());
        }
    }

    private IEnumerator AfterGateCheckPowerDelay()
    {
        yield return new WaitForSeconds(0.1f);
        gm.CheckPlayerPower();
    }
    private void DamageBonusAdd()
    {
        foreach (var player in gm.players)
        {
            player.GetComponent<GunManager>().currentWeapon.GetComponent<Gun>().damage += amount;
        }
    }

    private void FireRateBonusAdd()
    {
        foreach (var player in gm.players)
        {
            player.GetComponent<GunManager>().currentWeapon.GetComponent<Gun>().fireRate += amount;
        }
    }

    private void ChangeWeapon()
    {
        foreach (var player in gm.players)
        {
            if (archtronic)
            {
                player.GetComponent<GunManager>().ChangeWeapon(0);
            }
           
            else if (mauler)
            {
                player.GetComponent<GunManager>().ChangeWeapon(1);
            }
        
            else if (hellwailer)
            {
                player.GetComponent<GunManager>().ChangeWeapon(2);
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
                StartCoroutine(AddNewPlayerDamageBonusDelay(0));
            }
            else if (gm.playerCloneCount == 1)
            {
                playerClonePrefab[1].SetActive(true);
                StartCoroutine(AddNewPlayerDamageBonusDelay(1));
            }
            gm.playerCloneCount++;
        }
    }
    public IEnumerator AddNewPlayerDamageBonusDelay(int i)
    {
        yield return new WaitForSeconds(0.05f);
        playerClonePrefab[i].GetComponent<GunManager>().currentWeapon.GetComponent<Gun>().damage += 4;
    }
}


public enum BonusTypes
{
    AddPlayer,
    ChangeWeapon,
    DamageBonus,
    FireRateBonus
}