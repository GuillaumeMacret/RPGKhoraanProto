using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CombatEngine : MonoBehaviour
{
    public CombatMenuUI m_CombatMenuUI;

    public List<GeneralFightingEntity> m_FightingEntities;

    
    //Locks the timer loop when it's not null. Value indicates how many entities are still ready to play
    private int entitiesAbleToPlay = 0;
    // Prevents updates when not needed
    private bool lockUpdate = false;

    private int allyCount = 0, ennemyCount = 0;

    static bool CanPlay(GeneralFightingEntity e) { return e.CanPlay(); }

    // Start is called before the first frame update
    void Start()
    {
        CreateEntities();
        GetMaxEntitiesCptSpeed();
        CreateTargetButtons();
    }

    void CreateEntities()
    {
        allyCount = ennemyCount = 0;
        int allyXOffset = 0, ennemyXOffset = 0;
        foreach (string entityName in GlobalContext.FightingEntitiesNamesToInstantiate)
        {
            GeneralFightingEntity entity = FightingEntitiesStore.instance.getEntityPrefab(entityName);

            if (entity.playerControlled)
            {
                allyCount++;
                m_FightingEntities.Add(Instantiate(entity, new Vector3(3f + ((allyXOffset % 2 == 0)?2:0), allyXOffset, 0), Quaternion.identity));
                allyXOffset++;
            }
            else
            {
                ennemyCount++;
                m_FightingEntities.Add(Instantiate(entity, new Vector3(-3f + ((ennemyXOffset % 2 == 0) ? 2 : 0), ennemyXOffset, 0), Quaternion.identity));
                ennemyXOffset++;
            }
        }
    }
    
    void CreateTargetButtons()
    {
        //m_CombatMenuUI.ClearTargetButtons();

        foreach(GeneralFightingEntity entity in m_FightingEntities)
        {
            m_CombatMenuUI.CreateTargetButton(entity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!lockUpdate)
        {
            if (entitiesAbleToPlay == 0)
            {
                int maxCptSpeed = GetMaxEntitiesCptSpeed();
                IncreaseEntitiesCptSpeed(GeneralFightingEntity.MAX_SPEED - maxCptSpeed);
            }
            else
            {
                lockUpdate = true;
                MakeOneEntityPlay();
                lockUpdate = false;
            }
        }
    }

    private int GetMaxEntitiesCptSpeed()
    {
        int maxSpeedFound = int.MinValue;
        //AbstractFightingEntity nextEntiy = null;
        foreach (GeneralFightingEntity entity in m_FightingEntities)
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
        foreach (GeneralFightingEntity entity in m_FightingEntities)
        {
            entity.IncreaseCptSpeed(amount);
            if (entity.CanPlay())
            {
                //TODO Could also use a list of rdy players in the class. Is it more effective ?
                entitiesAbleToPlay++;
                //FIXME Debug purpose, delete this
                Debug.Log("[RECAP]" + m_FightingEntities[0] + "\n" + m_FightingEntities[1]);
            }
        }
    }

    public void MakeOneEntityPlay()
    {
        //TODO Maybe having a function pulling an entity and another one making it play will be better as we will have to loop while no action is given
        //TODO Could also use a list of rdy players in the class. Is it more effective ?
        GeneralFightingEntity entity = m_FightingEntities.Find(CanPlay);
        if (entity == null)
        {
            Debug.Log("[WARN] Function to make an entity play was called but no entity was found able to play, reseting counter");
            entitiesAbleToPlay = 0;
            //TODO should use this instead, above isn't clean
            //throw new Exception("Function to make an entity play was called but no entity was found able to play!!");
        }
        else
        {
            if (entity.playerControlled)
            {
                if (!m_CombatMenuUI.isLoaded()) m_CombatMenuUI.LoadActionsMenu(entity);

                CombatAction action = m_CombatMenuUI.GetAction();

                if(action != null)
                {
                    Debug.Log("[INFO]: " + entity + " Playing action " + action);
                    HandleAction(action);
                    //TODO Make different action recover speed
                    entity.ResetCptSpeed();
                    m_CombatMenuUI.UnloadMenu();
                    RemoveDeadEntities();
                    entitiesAbleToPlay--;
                    CheckBattleOver();
                }

                action = null;
            }
            else
            {
                Debug.Log("[To be implemented] NPC entity needs to play, skipping");
                //TODO
                entity.ResetCptSpeed();
                entitiesAbleToPlay--;
            }
        }
    }

    private void CheckBattleOver()
    {
        Debug.Log("Allies : " + allyCount + ", Ennemies : " + ennemyCount);
        if (allyCount <= 0) Quit.DoQuit();
        if(ennemyCount <= 0)
        {
            SceneManager.LoadScene(GlobalContext.precSceneName);
        }
    }

    //FIXME This function is fucking up
    private void RemoveDeadEntities()
    {
        List<GeneralFightingEntity> toRemove = new List<GeneralFightingEntity>();
        foreach(GeneralFightingEntity entity in m_FightingEntities)
        {
            if (entity.IsDead())
            {
                Debug.Log("[DEAD] " + entity + " is deaded");
                toRemove.Add(entity);
            }
        }
        
        foreach(GeneralFightingEntity entity in toRemove)
        {
            if (entity.playerControlled)
            {
                allyCount--;
            }
            else
            {
                ennemyCount--;
            }
            m_FightingEntities.Remove(entity);
            if (entity.CanPlay())
            {
                entitiesAbleToPlay--;
            }

            //CreateTargetButtons();
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
