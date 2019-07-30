using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEngine : MonoBehaviour
{
    //TODO ideas ...
    public CombatMenuUI m_MenuHud;

    public List<AbstractFightingEntity> m_FightingEntities;
    
    private bool lockTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        GetMaxEntitiesCptSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if(!lockTimer)
        {
            int maxCptSpeed = GetMaxEntitiesCptSpeed();
            IncreaseEntitiesCptSpeed(AbstractFightingEntity.MAX_SPEED - maxCptSpeed);
        }
        else
        {
            Debug.Log("Blocked");
            Debug.Log(m_FightingEntities);
            MakeEntitiesPlay();
        }
    }

    private int GetMaxEntitiesCptSpeed()
    {
        int maxSpeedFound = int.MinValue;
        //AbstractFightingEntity nextEntiy = null;
        foreach (AbstractFightingEntity entity in m_FightingEntities)
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
        foreach (AbstractFightingEntity entity in m_FightingEntities)
        {
            entity.IncreaseCptSpeed(amount);
            Debug.Log(entity.CanPlay() + " " + entity.playerControlled);
            if (entity.CanPlay() && entity.playerControlled)
            {
                lockTimer = true;
            }
        }
    }

    public void MakeEntitiesPlay()
    {
        foreach(AbstractFightingEntity entity in m_FightingEntities)
        {
            if (entity.CanPlay() && entity.playerControlled)
            {
                LoadMenu(entity);
                string action ;
                while((action = m_MenuHud.GetAction()) != null)
                {

                }
            }
        }
    }

    private void LoadMenu(AbstractFightingEntity entity)
    {
        //TODO Calls for menu class with given entity
        throw new NotImplementedException();
    }

    private void handleAction(string action)
    {
        Debug.Log("Handling action " + action);
        throw new NotImplementedException();
    }
}
