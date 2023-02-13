using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using DG.Tweening;
using UnityEngine;

public class KillerPillar : MonoBehaviour
{
    [Header("Companent")]
    
    [Tooltip("Assign players' dissolve materials.")]
    public Material[] dissolve;
   
    [Tooltip("Assign the game manager here to update the player's power.")]
    public GameManager gm;

    private void Awake()
    {
        //Reset Dissolve value
        foreach (var VARIABLE in dissolve)
        {
            VARIABLE.SetFloat("_Dissolve", 0);
        }
    }

    //When the player crashes into a killer pillar, it enables the player to dissolve and transition to a death animation. Different materials have been assigned for each one.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            var player = collision.gameObject.GetComponent<Player>();
            player.gunManager.currentWeapon.gameObject.SetActive(false);
            player.anim.SetTrigger("Die");
            player.tmp.gameObject.SetActive(false);
            player.transform.parent = null;
            player.GetComponent<BoxCollider>().enabled = false;

            if (player.gameObject.name == "Player")
            {
                float dissolveFloat = dissolve[0].GetFloat("_Dissolve");
                DOTween.To(()=> dissolveFloat, x=> dissolveFloat = x, 1, 0.5f).OnUpdate(() => dissolve[0].SetFloat("_Dissolve", dissolveFloat)).OnComplete(
                    () =>
                    {
                        player.gameObject.SetActive(false);
                    });
                return;
            }
            
            if (player.gameObject.name == "Right Player")
            {
                float dissolveFloat = dissolve[1].GetFloat("_Dissolve");
                DOTween.To(()=> dissolveFloat, x=> dissolveFloat = x, 1, 0.5f).OnUpdate(() => dissolve[1].SetFloat("_Dissolve", dissolveFloat)).OnComplete(
                    () =>
                    {
                        player.gameObject.SetActive(false);
                    });
                return;
            }

            if (player.gameObject.name == "Left Player")
            {
                float dissolveFloat = dissolve[2].GetFloat("_Dissolve");
                DOTween.To(()=> dissolveFloat, x=> dissolveFloat = x, 1, 0.5f).OnUpdate(() => dissolve[2].SetFloat("_Dissolve", dissolveFloat)).OnComplete(
                    () =>
                    {
                        player.gameObject.SetActive(false);
                    });
                return;
            }
            gm.CheckPlayerPower();
        }
    }
}
