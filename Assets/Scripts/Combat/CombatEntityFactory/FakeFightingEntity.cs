using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeFightingEntity : GeneralFightingEntity
{
    public FakeFightingEntity(int cptSpeed) : base(cptSpeed)
    {
        this.cptSpeed = cptSpeed;
        this.id = debugId++;
    }

    private void Start()
    {
        RecurentEntityInit();
    }
}
