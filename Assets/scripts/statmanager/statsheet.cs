using UnityEngine;

public class statsheet : MonoBehaviour
{

    [Header("Player Bars")]
    public float maxHealth = 250f;
    public float health = 250f;
    public float maxMana = 140f;
    public float mana = 140f;

    // IMPLEMENT STAMINA IF NEEDED LATER ON

    [Header("Player Stats")]

    public int vitality = 6; // certain DoT recover rate i.e. bleeding, some sickness maybe? will think of later / directly increases hit points, increases level based hit points, increases passive regen to a degree
    public int strength = 6; // directly increases STR based damage, increases equip weight cap
    public int agility = 6; // small additions to mvmt speed outside of combat / in turn based - determines move order, increases non-miss chance, increases dodge chance, crit chance / in dynamic - increases crit rate, increases time-before-noticing / will think of more 
    public int luck = 6; // directly affects luck based events - RNG slightly better, crit chance better, dodge chance better, hitrate better, certain DoTs not triggering possibly
    public int intelligence = 6; // directly increases spell damage, gives more mana
    public int mind = 6; // increases resistance to spell effects and fortifies user's spell effects / certain DoTs e.g. poison, mana sickness etc. / could be used to unlock certain support spells later on
    // public int arcane; // will think of later
    public int religion = 6; // increases user's affinity from the deities, specifically useful for paladin or religious cleric/medic, reaching X in religion will unlock deity you can pick and get stat bonuses/skills from
    
    // kms 

    [Header("Movement Changes")]

    public int speed; // affected by agi and class 

    public enum charClass 
    {
        Paladin,
        Tank, 
        Fighter, 
        Cleric, 
        Assassin, 
        Priest
    }

    [Header ("Class Selection")]

    public charClass playerclass;

}
