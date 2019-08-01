using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMenuUI : MonoBehaviour
{

    string action;
    bool menuLoaded;

    void Start()
    {
        //menuCanvasGroup.SetActive(false);
        //mainCombatMenu = GetComponentInChildren<GameObject>();
        gameObject.SetActive(false);
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
        UnloadMenu();
        return action;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            action = "attack";
            Debug.Log("Fire1 pressed in combat mneu");
            gameObject.SetActive(true);
        }
    }
}