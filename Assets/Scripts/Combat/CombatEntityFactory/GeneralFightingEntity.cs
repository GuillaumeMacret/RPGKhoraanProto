using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO Make it abstract, obviously
public class GeneralFightingEntity : MonoBehaviour
{
    public const int MAX_SPEED = 255;

    public Text hpText;

    protected static int debugId = 0;

    /*## private & protected var ##*/
    public string entityName;
    // Unit id, for testing purpose mainly
    protected int id;
    //Speed at start of the fight (stat + items)
    protected int baseSpeed;
    //Actual speed compting buff and debuff applied while fighting
    protected int actualSpeed;
    //TODO Statistic deported calss tryout
    protected CombatStatistics statistics;

    protected CombatFloatingHealthBar floatingHealthBar;

    //TODO add an array of debuff, storring they duration and values so we can calculate actualSpeed while it's private scope

    /*## public var ##*/
    protected int cptSpeed;
    public int CptSpeed { get => cptSpeed;}
    public bool playerControlled = true;

    // Start is called before the first frame update
    void Start()
    {
        RecurentEntityInit();
    }

    protected void RecurentEntityInit()
    {
        id = debugId++;
        statistics = GetComponentInChildren<CombatStatistics>();
        floatingHealthBar = GetComponentInChildren<CombatFloatingHealthBar>();
        baseSpeed = statistics.speed;
        actualSpeed = baseSpeed;
        cptSpeed = actualSpeed;
        hpText.text = statistics.GetCurrentHp() + " / " + statistics.maxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GeneralFightingEntity(int cptSpeed)
    {
        this.cptSpeed = cptSpeed;
        this.id = debugId++;
    }

    public override string ToString()
    {
        return (entityName + " Fighting Entity: {id : " + id + ", cptSpeed : " + cptSpeed + ", " + statistics.ToString() + "}");
    }

    public void IncreaseCptSpeed(int amount)
    {
        cptSpeed += amount;
    }

    public bool CanPlay()
    {
        return CptSpeed >= MAX_SPEED;
    }

    public void ResetCptSpeed()
    {
        cptSpeed = actualSpeed;
    }

    public void GetCombatMenu()
    {
        //TODO
    }

    //Calculates the real damage (substraction armor, ...) and calls for raw change of health
    public void ChangeHealth(int amout)
    {
        float ratio = statistics.ChangeHealth(amout);
        floatingHealthBar.UpdateFill(ratio);
        hpText.text = statistics.GetCurrentHp() + " / " + statistics.maxHp;
    }
}
