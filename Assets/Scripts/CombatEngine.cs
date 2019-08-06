using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEngine : MonoBehaviour
{
    public CombatMenuUI m_CombatMenuUI;

    public List<AbstractFightingEntity> m_FightingEntities;

    
    //Locks the timer loop when it's not null. Value indicates how many entities are still ready to play
    private int lockTimer = 0;

    static bool CanPlay(AbstractFightingEntity e) { return e.CanPlay(); }

    // Start is called before the first frame update
    void Start()
    {
        GetMaxEntitiesCptSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (lockTimer == 0)
        {
            int maxCptSpeed = GetMaxEntitiesCptSpeed();
            IncreaseEntitiesCptSpeed(AbstractFightingEntity.MAX_SPEED - maxCptSpeed);
        }
        else
        {
            MakeOneEntityPlay();
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
                //TODO Could also use a list of rdy players in the class. Is it more effective ?
                lockTimer++;
                //FIXME Debug purpose, delete this
                Debug.Log("[RECAP]" + m_FightingEntities[0] + "\n" + m_FightingEntities[1]);
            }
        }
    }

    public void MakeOneEntityPlay()
    {
        //TODO Maybe having a function pulling an entity and another one making it play will be better as we will have to loop while no action is given
        //TODO Could also use a list of rdy players in the class. Is it more effective ?
        AbstractFightingEntity entity = m_FightingEntities.Find(CanPlay);
        if (entity == null)
        {
            throw new Exception("Function to make an entity play was called but no entity was found able to play!!");
        }
        else
        {
            if (entity.playerControlled)
            {
                if (!m_CombatMenuUI.isLoaded()) m_CombatMenuUI.LoadMenu(entity);

                CombatAction action = m_CombatMenuUI.GetAction();

                if(action != null)
                {
                    Debug.Log("[INFO]: " + entity + " Playing action " + action);
                    HandleAction(action);
                    //TODO Make different action recover speed
                    entity.ResetCptSpeed();
                    m_CombatMenuUI.UnloadMenu();
                    lockTimer--;
                }

                action = null;
            }
        }
    }
    
    /**
     * Handles the given action : Adjust hp, mp, ...
     **/
    private void HandleAction(CombatAction action)
    {
        Debug.Assert(action != null);
        action.HandleAction();
    }
}
