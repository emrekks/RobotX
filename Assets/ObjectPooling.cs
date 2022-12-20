using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public List<Projectile> pooledObjects = new List<Projectile>();
    public Projectile objectToPool;
    public int amountToPool;

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
    }

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
}
