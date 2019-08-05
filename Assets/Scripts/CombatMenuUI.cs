using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMenuUI : MonoBehaviour
{

    public static Action action;

    public static AbstractFightingEntity entityPlaying;
    public bool isLoaded() { return entityPlaying != null; }

    void Start()
    {
        entityPlaying = null;
        action = null;
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

    public Action GetAction()
    {
        Action returnedAction = action;
        action = null;
        return returnedAction;
    }

}