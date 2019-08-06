using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMenuUI : MonoBehaviour
{

    CombatAction action;

    AbstractFightingEntity entityPlaying;
    public AbstractFightingEntity EntityPlaying { get => entityPlaying;}

    public bool isLoaded() { return EntityPlaying != null; }

    void Start()
    {
        entityPlaying = null;
        action = new CombatAction();
    }

    void Update()
    {
        
    }

    public void LoadMenu(AbstractFightingEntity entity)
    {
        if (isLoaded()) return;

        //TODO Load menu
        Debug.Log("[MENU IS LOADING] For : " + entity);
        entityPlaying = entity;
    }

    public void UnloadMenu()
    {
        if (!isLoaded()) return;

        //TODO unload menu
        //TODO destroy childs ?
        Debug.Log("[MENU IS UNLOADING]");
        entityPlaying = null;
    }

    public CombatAction GetAction()
    {
        if (action.IsBuilt())
        {
            CombatAction returnedAction = new CombatAction(action);
            action = new CombatAction();
            return returnedAction;
        }
        return null;
    }

    public void SetAction(string actionName)
    {
        action.SetAction(actionName);
    }

    public void SetTargets(List<AbstractFightingEntity> targets)
    {
        action.SetTargets(targets);
    }

    public void SetActionReady()
    {
        action.Built = true;
    }
}