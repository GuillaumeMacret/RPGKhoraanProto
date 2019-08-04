using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMenuUI : MonoBehaviour
{

    string action;
    Action m_Action;

    AbstractFightingEntity entityPlaying;
    public bool isLoaded() { return entityPlaying != null; }

    void Start()
    {
        entityPlaying = null;
        m_Action = null;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            List<AbstractFightingEntity> targets = new List<AbstractFightingEntity>(1);
            targets.Add(entityPlaying);//FIXME Do a target select system
            m_Action = new Action(targets);
        }
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
        Action returnedAction = m_Action;
        m_Action = null;
        return returnedAction;
    }

}