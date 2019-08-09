using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateActionOnClick : MonoBehaviour
{
    public void CreateAction(string actionName)
    {
        CombatMenuUI.instance.SetAction(actionName);
    }
}
