using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEngine : MonoBehaviour
{
    public List<AbstractFightingEntity> fightingEntities;
    
    private bool lockTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        AbstractFightingEntity e1 = new AbstractFightingEntity(30);
        AbstractFightingEntity e2 = new AbstractFightingEntity(10);
        AbstractFightingEntity e3 = new AbstractFightingEntity(40);
        AbstractFightingEntity e4 = new AbstractFightingEntity(50);
        fightingEntities.Add(e1);
        fightingEntities.Add(e2);
        fightingEntities.Add(e3);
        fightingEntities.Add(e4);
        GetMaxEntitiesCptSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if(!lockTimer)
        {
            IncreaseEntitiesCptSpeed(AbstractFightingEntity.MAX_SPEED - GetMaxEntitiesCptSpeed());
        }
        else
        {
            Debug.Log("Blocked");
            Debug.Log(fightingEntities);
        }//TODO TEST
    }

    private int GetMaxEntitiesCptSpeed()
    {
        int maxSpeedFound = int.MinValue;
        //AbstractFightingEntity nextEntiy = null;
        foreach (AbstractFightingEntity entity in fightingEntities)
        {
            if(entity.CptSpeed > maxSpeedFound)
            {
                maxSpeedFound = entity.CptSpeed;
                //nextEntiy = entity;
            }
        }
        return maxSpeedFound;
    }

    private void IncreaseEntitiesCptSpeed(int amount)
    {
        foreach (AbstractFightingEntity entity in fightingEntities)
        {
            entity.IncreaseCptSpeed(amount);
            if (entity.CanPlay() && entity.IsPlayerControlled)
            {
                lockTimer = true;
            }
        }
    }

    public void MakeEntitiesPlay()
    {
        foreach(AbstractFightingEntity entity in fightingEntities)
        {
            if (entity.CanPlay())
            {
                entity.Play();
            }
        }
    }
}
