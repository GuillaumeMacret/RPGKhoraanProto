using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeFightingEntity : AbstractFightingEntity
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
