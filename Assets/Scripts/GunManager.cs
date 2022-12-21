using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
   public GameObject currentWeapon;

   public GameObject[] weapons; //0 = Ak47// 1 = Pistol// 2 = Rpc

   private void Start()
   {
      currentWeapon = weapons[1];
      currentWeapon.SetActive(true);
   }

   public void ChangeWeapon(int i)
   {
      if (currentWeapon != weapons[i])
      {
         currentWeapon.SetActive(false);
         currentWeapon = weapons[i];
         weapons[i].SetActive(true);
         var currentWeaponData = currentWeapon.GetComponent<Gun>();
         currentWeaponData.damage = currentWeaponData.gunData.damage;
         currentWeaponData.fireRate = currentWeaponData.gunData.fireRate;
      }
   }
}
