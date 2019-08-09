using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMenuUI : MonoBehaviour
{
    public static CombatMenuUI instance = null;

    CombatAction action = null;

    AbstractFightingEntity entityPlaying;
    public AbstractFightingEntity EntityPlaying { get => entityPlaying;}

    public SelectTargetOnClick targetButtonPrefab;

    public GameObject targetsMenuContainer;

    public bool isLoaded() { return EntityPlaying != null; }

    void Awake()
    {
        entityPlaying = null;
        //action = new CombatAction();
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Update()
    {
        
    }

    public void LoadActionsMenu(AbstractFightingEntity entity)
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

    public void CreateTargetButton(AbstractFightingEntity entity)
    {
        SelectTargetOnClick newTargetButtonPrefab = Instantiate(targetButtonPrefab);
        newTargetButtonPrefab.SetTarget(entity);
        newTargetButtonPrefab.transform.SetParent(targetsMenuContainer.transform);
    }

    public CombatAction GetAction()
    {
        if (action != null && action.IsBuilt())
        {
            CombatAction returnedAction = action;
            action = null;
            return returnedAction;
        }
        return null;
    }

    public void SetAction(string actionName)
    {
        action = CombatAction.CreateAction(actionName);
        //action.SetAction(actionName);
        Debug.Log("Action setted new action is " + action);
    }

    public void SetTargets(List<AbstractFightingEntity> targets)
    {
        action.SetTargets(targets);
    }

    public void SetTarget(AbstractFightingEntity target)
    {
        action.SetTarget(target);
        Debug.Log("Targets setted new action is " + action);
    }
}