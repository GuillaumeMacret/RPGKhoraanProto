using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMenuUI : MonoBehaviour
{

    string action;
    bool menuLoaded;

    GameObject attackText;

    public GameObject menuCanvasGroup;

    void Start()
    {
        //menuCanvasGroup.SetActive(false);
        attackText = menuCanvasGroup.GetComponentInChildren<AttackText>();
        attackText.transform. = 100;
        //attackText.SetActive(false);
    }

    public void LoadMenu(AbstractFightingEntity entity)
    {
        if (menuLoaded) return;

        //TODO Load menu
        menuCanvasGroup.SetActive(true);

        menuLoaded = true;
    }

    public void UnloadMenu()
    {
        if (!menuLoaded) return;

        //TODO unload menu
        //TODO destroy childs ?
        menuCanvasGroup.SetActive(false);
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

    }
}
