using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStatistics : MonoBehaviour
{
    public int maxHp;
    private int currentHp;

    public int speed;

    // Start is called before the first frame update
    void Awake()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override string ToString()
    {
        return "CombatStatistics: {currentHp/maxHp : " + currentHp + "/" + maxHp + " speed : " + speed + "}";
    }

    public int GetCurrentHp()
    {
        return currentHp;
    }

    /**
     * Raw change of health. Armor, spells, ... are handled in parent ->tbc
     * @param the amount added
     * @return The ratio currentHp/maxHp
     **/
    public float ChangeHealth(int amount)
    {
        currentHp = Mathf.Clamp(currentHp + amount, 0, maxHp);
        return (float)currentHp / maxHp;
    }
}
