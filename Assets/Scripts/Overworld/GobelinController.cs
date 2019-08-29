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
        Debug.Log("Loading combat scene ...");
        SceneManager.LoadScene("CombatScene");
    }
}
