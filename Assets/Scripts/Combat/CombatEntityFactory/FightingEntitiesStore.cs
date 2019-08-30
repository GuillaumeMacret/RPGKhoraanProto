using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingEntitiesStore : MonoBehaviour
{

    public static FightingEntitiesStore instance = null;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public GeneralFightingEntity[] entityStore;

    public GeneralFightingEntity getEntityPrefab(string entityName)
    {
        foreach(GeneralFightingEntity entity in entityStore)
        {
            if (entity.entityName.Equals(entityName)) return entity;
        }

        //TODO throw exception
        Debug.LogError("No entity found for : " + entityName);
        return null;
    }
}
