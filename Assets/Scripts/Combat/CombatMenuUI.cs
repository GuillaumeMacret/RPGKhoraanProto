using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatMenuUI : MonoBehaviour
{
    public static CombatMenuUI instance = null;

    CombatAction action = null;

    GeneralFightingEntity entityPlaying;
    public GeneralFightingEntity EntityPlaying { get => entityPlaying;}

    public SelectTargetOnClick targetButtonPrefab;

    public GameObject targetsMenuContainer;

    public bool isLoaded() { return EntityPlaying != null; }

    public Text topLabel;

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

    public void LoadActionsMenu(GeneralFightingEntity entity)
    {
        if (isLoaded()) return;

        //TODO Load menu
        Debug.Log("[MENU IS LOADING] For : " + entity);
        entityPlaying = entity;
        topLabel.text = entity.entityName;
    }

    public void UnloadMenu()
    {
        if (!isLoaded()) return;

        //TODO unload menu
        //TODO destroy childs ?
        Debug.Log("[MENU IS UNLOADING]");
        entityPlaying = null;
    }

    public void CreateTargetButton(GeneralFightingEntity entity)
    {
        SelectTargetOnClick newTargetButtonPrefab = Instantiate(targetButtonPrefab);
        newTargetButtonPrefab.name = entity.entityName;
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

    public void SetTargets(List<GeneralFightingEntity> targets)
    {
        action.SetTargets(targets);
    }

    public void SetTarget(GeneralFightingEntity target)
    {
        action.SetTarget(target);
        Debug.Log("Targets setted new action is " + action);
    }
}