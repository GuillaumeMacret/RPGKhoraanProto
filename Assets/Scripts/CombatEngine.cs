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
        string action = null;
        foreach(AbstractFightingEntity entity in m_FightingEntities)
        {
            if (entity.CanPlay() && entity.playerControlled)
            {
                m_MenuHud.LoadMenu(entity);
            }
            action = WaitForAction();
            HandleAction(action);
        }
    }

    private string WaitForAction()
    {
        //TODO Active wainting is bad
        string action = null;
        while ((action = m_MenuHud.GetAction()) == null) ;
        return action;
    }

    private void HandleAction(string action)
    {
        Debug.Log("Handling action " + action);
        throw new NotImplementedException();
    }
}
