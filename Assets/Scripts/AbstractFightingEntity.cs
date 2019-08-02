using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Make it abstract, obviously
public class AbstractFightingEntity : MonoBehaviour
{
    public const int MAX_SPEED = 255;

    private static int debugId = 0;

    /*## private var ##*/
    int id;
    //Speed at start of the fight (stat + items)
    public int baseSpeed;
    //Actual speed compting buff and debuff applied while fighting
    int actualSpeed;
    //TODO Statistic deported calss tryout
    CombatStatistics statistics;

    //TODO add an array of debuff, storring they duration and values so we can calculate actualSpeed while it's private scope

    /*## public var ##*/
    private int cptSpeed;
    public int CptSpeed { get => cptSpeed; set => cptSpeed = value; }
    public bool playerControlled = true;

    // Start is called before the first frame update
    void Start()
    {
        id = debugId++;
        actualSpeed = baseSpeed;
        cptSpeed = actualSpeed;
        statistics = GetComponent<CombatStatistics>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public AbstractFightingEntity(int cptSpeed)
    {
        this.cptSpeed = cptSpeed;
        this.id = debugId++;
    }

    public override string ToString()
    {
        return ("Abstract Fighting Entity: {id : " + id + ", cptSpeed : " + cptSpeed + ", " + statistics + "}");
    }

    public void IncreaseCptSpeed(int amount)
    {
        CptSpeed += amount;
    }

    public bool CanPlay()
    {
        return CptSpeed >= MAX_SPEED;
    }

    public void ResetCptSpeed()
    {
        CptSpeed = actualSpeed;
    }

    public void GetCombatMenu()
    {
        //TODO
    }
}
