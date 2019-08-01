using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEngine : MonoBehaviour
{
    //TODO ideas ...
    public CombatMenuUI m_CombatMenuUI;

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
        if (!lockTimer)
        {
            int maxCptSpeed = GetMaxEntitiesCptSpeed();
            IncreaseEntitiesCptSpeed(AbstractFightingEntity.MAX_SPEED - maxCptSpeed);
        }
        else
        {
            MakeEntitiesPlay();
        }

        //TODO delete me
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1 pressed in Combat engine");
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
                m_CombatMenuUI.LoadMenu(entity);
            }
            action = WaitForAction();
            HandleAction(action);
        }
    }

    private string WaitForAction()
    {
        return m_CombatMenuUI.GetAction();
    }

    private void HandleAction(string action)
    {
        if (action != null)
        {
            Debug.Log("Handling action " + action);
        }
        throw new NotImplementedException();
    }
}
