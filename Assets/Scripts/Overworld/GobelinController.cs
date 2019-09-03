using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GobelinController : NonPlayableCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnRaycast()
    {
        DialogBox.instance.SetText(GetComponentInChildren<Text>().text);
        DialogBox.instance.SetActive(true);

        ChoiceBox.instance.ClearItems();
        ChoiceBox.instance.AddItem("Oui",StartRingFight);
        ChoiceBox.instance.AddItem("Non",ShowTauntMessage);

        ChoiceBox.instance.SetActive(true);
    }

    private int ShowTauntMessage(string arg)
    {
        DialogBox.instance.SetText("Tu devrais revenir après avoir bu un coup alors !");
        DialogBox.instance.SetActive(true);
        return 1;
    }

    private int StartRingFight(string s)
    {
        Debug.Log("From " + GlobalContext.precSceneName + " to combat scene ...");

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            throw new System.Exception("Can't find the player in current scene !");
        }
        else
        {
            GlobalContext.playerTransformPosition = player.transform.position;
            GlobalContext.useSavedPosition = true;
            Debug.Log("Transform stored : " + GlobalContext.playerTransformPosition);
        }

        GlobalContext.precSceneName = SceneManager.GetActiveScene().name;

        GlobalContext.FightingEntitiesNamesToInstantiate.Clear();
        GlobalContext.FightingEntitiesNamesToInstantiate.Add("Player1");
        GlobalContext.FightingEntitiesNamesToInstantiate.Add("Player2");
        GlobalContext.FightingEntitiesNamesToInstantiate.Add("NieilsRingOpponent1");
        GlobalContext.FightingEntitiesNamesToInstantiate.Add("NieilsRingOpponent1");

        SceneManager.LoadScene("CombatScene");

        return 1;
    }
}
