using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateActionOnClick : MonoBehaviour
{
    public CombatMenuUI combatMenuUI;

    public void CreateAction(string actionName)
    {
        combatMenuUI.SetAction(actionName);

        //TODO Remove this part
        combatMenuUI.SetActionReady();
        //
    }
}
