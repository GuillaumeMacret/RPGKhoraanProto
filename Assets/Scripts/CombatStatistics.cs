using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStatistics : MonoBehaviour
{
    public int hpMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string ToString()
    {
        return "CombatStatistics: {hpMax : " + hpMax + "}";
    }
}
