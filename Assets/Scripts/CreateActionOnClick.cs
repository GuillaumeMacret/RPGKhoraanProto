using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateActionOnClick : MonoBehaviour
{
    public void CreateAction(string actionName)
    {
        CombatMenuUI.action.SetAction(actionName);
        List<AbstractFightingEntity> targets = new List<AbstractFightingEntity>();
        targets.Add(CombatMenuUI.entityPlaying);
        CombatMenuUI.action.SetTargets(targets);
    }
}
