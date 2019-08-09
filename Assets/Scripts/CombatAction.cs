﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAction
{
    protected string name;
    //Strengh of the attack. Negative value indicates damages, positive is healing.
    protected int potency;
    List<AbstractFightingEntity> m_TargetedEntities;
    protected bool built;
    public bool Built { get => built; set => built = value; }

    public bool IsBuilt() { return Built; }
    
    public static CombatAction CreateAction(string actionName)
    {
        CombatAction action = null; 
        if(actionName == "attack")
        {
            action = new AttackAction();
        }
        else if (actionName == "heal")
        {
            action = new HealAction();
        }

        if(action != null)
        {
            //TODO Use dynamic targets menu printing
            action.m_TargetedEntities = new List<AbstractFightingEntity>();
            //
            action.TestIfActionIsReady();
        }
        
        return action;
    }
    
    public void SetAction(string actionName)
    {
        name = actionName;
        potency = -5;
        //TODO Replace this with a builder

    }

    private void TestIfActionIsReady()
    {
        built = (name != "") && (m_TargetedEntities.Count > 0);
    }

    //FIXME Should copy this instead of passing ref shouldn't we?
    public void SetTargets(List<AbstractFightingEntity> targets)
    {
        //TODO
        throw new NotImplementedException();
        TestIfActionIsReady();
    }

    /**
     * Clear the current target list and adds the target given
     * @param the target to add to the list
     **/
    public void SetTarget(AbstractFightingEntity target)
    {
        m_TargetedEntities = new List<AbstractFightingEntity>();
        m_TargetedEntities.Add(target);
        TestIfActionIsReady();
    }

    /**
     * Default Action handling. Special effects should be applied here
     **/
    public void HandleAction()
    {
        foreach(AbstractFightingEntity target in m_TargetedEntities)
        {
            target.ChangeHealth(potency);
        }
    }

    public override string ToString()
    {
        //TODO
        return "Combat Action : {Name: " + name + ", potency: " + potency + ", targets:[0]"+m_TargetedEntities[0] + ", built: " + built + "}";
    }
}
