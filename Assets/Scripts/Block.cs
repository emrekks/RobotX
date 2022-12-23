using TMPro;
using DG.Tweening;
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
    public Transform hand;
    public Enemy enemy;

    [Space(10)] [Header("Gun Type Settings")] //0 = Archtronic// 1 = Mauler// 2 = Hellwailer 
    public bool archtronic;
    public bool mauler;
    public bool hellwailer;

    private void Start()
    {
        Health = 100;
        
        tmp.text = Health.ToString();
        
        if (archtronic)
        {
            Instantiate(guns[0], hand);
            guns[0].gameObject.SetActive(true);
        }

        else if (mauler)
        {
            Instantiate(guns[1], hand);
            guns[1].gameObject.SetActive(true);
        }
        
        else if (hellwailer)
        {
            Instantiate(guns[2], hand);
            guns[2].gameObject.SetActive(true);
        }
    }

    public void Damage(int amount)
    {
        Health -= amount;
        
        transform.DORewind();
        transform.DOPunchScale(new Vector3(0.3f,0.15f,0.3f), 0.5f);

        
        if (Health <= 0)
        {
            Health = 0;

            for (int i = 0; i < gm.playerCloneCount + 1; i++)
            {
                if (archtronic)
                {
                    GunManager[i].ChangeWeapon(0);
                }

                else if (mauler)
                {
                    GunManager[i].ChangeWeapon(1);
                }
        
                else if (hellwailer)
                {
                    GunManager[i].ChangeWeapon(2);
                }
            }

            gameObject.SetActive(false);
        }
        
        tmp.text = Health.ToString();
    }
}
