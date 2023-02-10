using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using DG.Tweening;
using UnityEngine;

public class KillerPillar : MonoBehaviour
{
    public Material[] dissolve;

    private void Awake()
    {
        foreach (var VARIABLE in dissolve)
        {
            VARIABLE.SetFloat("_Dissolve", 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            var player = collision.gameObject.GetComponent<Player>();
            player.gunManager.currentWeapon.gameObject.SetActive(false);
            player.anim.SetTrigger("Die");
            player.tmp.gameObject.SetActive(false);
            player.transform.parent = null;

            if (collision.gameObject.name == "Player")
            {
                float dissolveFloat = dissolve[0].GetFloat("_Dissolve");
                DOTween.To(()=> dissolveFloat, x=> dissolveFloat = x, 1, 0.5f).OnUpdate(() => dissolve[0].SetFloat("_Dissolve", dissolveFloat)).OnComplete(
                    () =>
                    {
                        collision.gameObject.SetActive(false);
                    });
                return;
            }
            
            if (collision.gameObject.name == "Right Player")
            {
                float dissolveFloat = dissolve[1].GetFloat("_Dissolve");
                DOTween.To(()=> dissolveFloat, x=> dissolveFloat = x, 1, 0.5f).OnUpdate(() => dissolve[1].SetFloat("_Dissolve", dissolveFloat)).OnComplete(
                    () =>
                    {
                        collision.gameObject.SetActive(false);
                    });
                return;
            }

            else
            {
                float dissolveFloat = dissolve[2].GetFloat("_Dissolve");
                DOTween.To(()=> dissolveFloat, x=> dissolveFloat = x, 1, 0.5f).OnUpdate(() => dissolve[2].SetFloat("_Dissolve", dissolveFloat)).OnComplete(
                    () =>
                    {
                        collision.gameObject.SetActive(false);
                    });
                return;
            }
        }
    }
}
