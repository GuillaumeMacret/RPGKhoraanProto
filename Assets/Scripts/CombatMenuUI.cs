using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMenuUI : MonoBehaviour
{

    string action;
    bool menuLoaded;
    public bool isLoaded() { return menuLoaded; }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            action = "attack";
            Debug.Log("Fire1 pressed in combat mneu");
        }
    }

    public void LoadMenu(AbstractFightingEntity entity)
    {
        if (menuLoaded) return;

        //TODO Load menu

        menuLoaded = true;
    }

    public void UnloadMenu()
    {
        if (!menuLoaded) return;
        
        //TODO unload menu
        //TODO destroy childs ?
        menuLoaded = false;
    }

    public string GetAction()
    {
        if (action == null) return null;
        string actionToReturn = action;
        action = null;
        UnloadMenu();
        return actionToReturn;
    }

}