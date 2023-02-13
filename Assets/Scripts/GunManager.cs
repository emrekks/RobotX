using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
   [Header("Companent")]
   public GameObject currentWeapon;
  
   [Tooltip("0 = Archtronic// 1 = Mauler// 2 = Hellwailer")]
   public GameObject[] weapons;

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
         currentWeapon.SetActive(true);
         var currentWeaponData = currentWeapon.GetComponent<Gun>();
         currentWeaponData.damage = currentWeaponData.gunData.damage;
         currentWeaponData.fireRate = currentWeaponData.gunData.fireRate;
      }
   }
}
