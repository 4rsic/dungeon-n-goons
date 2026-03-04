using System;
using UnityEngine;

public class playerStats : statsheet
{
    public void OnValidate()
    {
        ResetClassModifiers();
        ApplyClassModifiers();
        maxHealth = (float)(200f + (7.1 * vitality) + (5 * strength));
        health = maxHealth;
        maxMana = (float)(100f + (mind * 6.5) + (4.3 * intelligence));
        mana = maxMana;
        speed = 4f + (float)(0.6 * agility / 6);
        Debug.Log(speed);
    }

}
