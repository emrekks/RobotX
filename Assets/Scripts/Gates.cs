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
    public GunManager gunManager;
    public TextMeshPro tmp;
    public GameObject[] playerClonePrefab;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (bonusTypes)
            {
                case BonusTypes.AddPlayer:
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
                    break;

                case BonusTypes.DamageBonus:
                    gunManager.currentWeapon.GetComponent<Gun>().damage += amount;
                    break;
                
                case BonusTypes.FireRateBonus:
                    gunManager.currentWeapon.GetComponent<Gun>().fireRate += amount;
                    break;
            }
        }
    }
}

public enum BonusTypes
{
    AddPlayer,
    DamageBonus,
    FireRateBonus
}