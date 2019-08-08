using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAction
{
    string name;
    //Strengh of the attack. Negative value indicates damages, positive is healing.
    int potency;
    List<AbstractFightingEntity> m_TargetedEntities;
    bool built;
    public bool Built { get => built; set => built = value; }

    public bool IsBuilt() { return Built; }

    public CombatAction()
    {
        name = "";
        potency = 0;
        m_TargetedEntities = new List<AbstractFightingEntity>();
        Debug.Log("Blank construct");
    }

    public CombatAction(CombatAction action)
    {
        name = action.name;
        potency = action.potency;
        m_TargetedEntities = new List<AbstractFightingEntity>();
        foreach(AbstractFightingEntity target in action.m_TargetedEntities)
        {
            m_TargetedEntities.Add(target);
        }
        Built = action.Built;
    }

    public CombatAction(List<AbstractFightingEntity> targets)
    {
        name = "attack";
        potency = -5;
        m_TargetedEntities = targets;
    }

    public void SetAction(string actionName)
    {
        name = actionName;
        potency = -5;
        //TODO Replace this with a builder
    }

    //FIXME Should copy this instead of passing ref shouldn't we?
    public void SetTargets(List<AbstractFightingEntity> targets)
    {
        m_TargetedEntities = targets;
    }

    /**
     * Clear the current target list and adds the target given
     * @param the target to add to the list
     **/
    public void SetTarget(AbstractFightingEntity target)
    {
        m_TargetedEntities = new List<AbstractFightingEntity>();
        m_TargetedEntities.Add(target);
    }

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
