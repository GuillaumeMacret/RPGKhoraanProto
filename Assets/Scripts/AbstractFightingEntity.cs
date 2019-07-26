using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractFightingEntity : MonoBehaviour
{
    public const int MAX_SPEED = 255;

    private static int debugId = 0;

    /*## private var ##*/
    int id;
    //Speed at start of the fight (stat + items)
    int baseSpeed;
    //Actual speed compting buff and debuff applied while fighting
    int actualSpeed;

    /*## public var ##*/
    private int cptSpeed;
    public int CptSpeed { get => cptSpeed; set => cptSpeed = value; }
    private bool playerControlled;
    public bool IsPlayerControlled { get => playerControlled; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public AbstractFightingEntity(int cptSpeed)
    {
        this.cptSpeed = cptSpeed;
        this.id = debugId++;
        playerControlled = true;
    }

    public override String ToString()
    {
        return ("Abstract Fighting Entity: {id : " + id + ", cptSpeed : " + cptSpeed + "}");
    }

    public void IncreaseCptSpeed(int amount)
    {
        CptSpeed += amount;
    }

    public bool CanPlay()
    {
        return CptSpeed > MAX_SPEED;
    }

    public void Play()
    {
        throw new NotImplementedException();
        bool hasPlayed = false;

        if (hasPlayed)
        {
            ResetCptSpeed();
        }
    }

    private void ResetCptSpeed()
    {
        CptSpeed = actualSpeed;
    }
}
