using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
   public GameObject currentWeapon;

   public GameObject[] weapons; //0 = Ak47// 1 = Pistol// 2 = Rpc

   public void ChangeWeapon(int i)
   {
      if (currentWeapon != weapons[i])
      {
         currentWeapon.SetActive(false);
         weapons[i].SetActive(true);
      }
   }
}
