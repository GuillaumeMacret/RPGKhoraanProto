using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        GlobalContext.precSceneName = SceneManager.GetActiveScene().name;
        Debug.Log("From " + GlobalContext.precSceneName + " to combat scene ...");
        GlobalContext.FightingEntitiesNamesToInstantiate.Clear();
        GlobalContext.FightingEntitiesNamesToInstantiate.Add("Player1");
        GlobalContext.FightingEntitiesNamesToInstantiate.Add("Player2");
        GlobalContext.FightingEntitiesNamesToInstantiate.Add("NieilsRingOpponent1");
        GlobalContext.FightingEntitiesNamesToInstantiate.Add("NieilsRingOpponent1");
        SceneManager.LoadScene("CombatScene");
    }
}
