using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    //Bullet
    public List<Projectile> pooledObjects = new List<Projectile>();
    public Projectile objectToPool;
    public int amountToPool;
    //MuzzleFlash
    public List<GameObject> muzzleFlashObjects = new List<GameObject>();
    public GameObject muzzleFlashToPool;
    public int amountMuzzleToPool;
    public Transform muzzlePos;

    #region Singleton
    
    public static ObjectPooling instance;

    void Awake() 
    {
        instance = this;
    }

    #endregion

    void Start()
    {
        for (int i = 0; i < amountToPool; i++) 
        {
            Projectile obj = Instantiate(objectToPool, transform);
            obj.gameObject.SetActive(false); 
            pooledObjects.Add(obj);
        }
        
        for (int i = 0; i < amountMuzzleToPool; i++) 
        {
            GameObject obj = Instantiate(muzzleFlashToPool, muzzlePos);
            obj.gameObject.SetActive(false); 
            muzzleFlashObjects.Add(obj);
        }
    }

    //Bullet
    public Projectile GetProjectileFromPool()
    {
        for (int i = 0; i < pooledObjects.Count; i++) 
        {
            if (!pooledObjects[i].gameObject.activeSelf)
            {
                return pooledObjects[i];
            }
        }
        
        return null;
    }

    public void GetProjectileBackToPool(Projectile projectile)
    {
        projectile.rb.velocity = Vector3.zero;
        projectile.gameObject.SetActive(false);
    }
    
    //MuzzleFlash
    
    public GameObject GetMuzzleFromPool()
    {
        for (int i = 0; i < muzzleFlashObjects.Count; i++) 
        {
            if (!muzzleFlashObjects[i].gameObject.activeSelf)
            {
                return muzzleFlashObjects[i];
            }
        }
        
        return null;
    }

    public void GetMuzzleBackToPool(GameObject muzzleFlash)
    {
        muzzleFlash.gameObject.SetActive(false);
    }
}
