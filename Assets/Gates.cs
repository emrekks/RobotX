using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gates : MonoBehaviour
{
    public PlayerMechanics playerMechanic;
    public BonusTypes bonusTypes;
    public GunManager gunManager;
    public TextMeshPro tmp;
    public bool ak47, pistol, rpg; //0 = Ak47// 1 = Pistol// 2 = Rpc
    public int amount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (bonusTypes)
            {
                case BonusTypes.AddPlayer:
                    Instantiate(playerMechanic, playerMechanic.transform.position, Quaternion.identity);
                    break;
                case BonusTypes.ChangeWeapon:
                    if (ak47)
                    {
                        gunManager.ChangeWeapon(0);
                    }
                    else if (pistol)
                    {
                        gunManager.ChangeWeapon(1);
                    }
                    else if (rpg)
                    {
                        gunManager.ChangeWeapon(2);
                    }
                    break;
                case BonusTypes.DamageBonus:
                    other.GetComponentInChildren<GunData>().damage += amount;
                    break;
                case BonusTypes.FireRateBonus:
                    other.GetComponentInChildren<GunData>().fireRate += amount;
                    break;
            }
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