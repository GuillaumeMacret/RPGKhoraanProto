using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    string name;
    //Strengh of the attack. Negative value indicates damages, positive is healing.
    int potency;
    List<AbstractFightingEntity> m_TargetedEntities;

    public Action(List<AbstractFightingEntity> targets)
    {
        name = "attack";
        potency = -5;
        m_TargetedEntities = targets;
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
        return name;
    }
}
