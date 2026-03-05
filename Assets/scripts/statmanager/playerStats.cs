using System;
using UnityEngine;

public class playerStats : statsheet
{
    [Header("Player Bars")]
    public float maxHealth = 250f;
    public float health = 250f;
    public float maxMana = 140f;
    public float mana = 140f;

    public float speed = 4f; // affected by agi and class 

    public void OnValidate()
    {
        ResetClassModifiers();
        ApplyClassModifiers();
        maxHealth = (float)(200f + (7.1 * vitality) + (5 * strength));
        health = maxHealth;
        maxMana = (float)(100f + (mind * 6.5) + (4.3 * intelligence));
        mana = maxMana;
        speed = 4.5f + (float)(0.6 * agility / 6);
        Debug.Log(speed);
        
    }

}
