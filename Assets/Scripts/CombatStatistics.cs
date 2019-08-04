using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStatistics : MonoBehaviour
{
    public int maxHp;
    private int currentHp;

    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override string ToString()
    {
        return "CombatStatistics: {currentHp/maxHp : " + currentHp + "/" + maxHp + "speed : " + speed + "}";
    }

    public int GetCurrentHp()
    {
        return currentHp;
    }

    public void ChangeHealth(int value)
    {
        Mathf.Clamp(value, 0, maxHp);
    }
}
