using UnityEngine;

public class statsheet : MonoBehaviour
{

    // IMPLEMENT STAMINA IF NEEDED LATER ON

    [Header("Player Stats")]

    public int vitality = 6; // certain DoT recover rate i.e. bleeding, some sickness maybe? will think of later / directly increases hit points, increases level based hit points, increases passive regen to a degree
    public int strength = 6; // directly increases STR based damage, increases equip weight cap
    public float agility = 6f; // small additions to mvmt speed outside of combat / in turn based - determines move order, increases non-miss chance, increases dodge chance, crit chance / in dynamic - increases crit rate, increases time-before-noticing / will think of more 
    public int luck = 6; // directly affects luck based events - RNG slightly better, crit chance better, dodge chance better, hitrate better, certain DoTs not triggering possibly
    public int intelligence = 6; // directly increases spell damage, gives more mana
    public int mind = 6; // increases resistance to spell effects and fortifies user's spell effects / certain DoTs e.g. poison, mana sickness etc. / could be used to unlock certain support spells later on
    // public int arcane; // will think of later
    public int religion = 6; // increases user's affinity from the deities, specifically useful for paladin or religious cleric/medic, reaching X in religion will unlock deity you can pick and get stat bonuses/skills from
    
    // kms 
    public enum charClass 
    {
        Paladin,
        Tank, 
        Fighter, 
        Cleric, 
        Assassin, 
        Priest,
        Nitwit,
        Cultist
    }

    [Header ("Class Selection")]

    public charClass pclass;

    public void ApplyClassModifiers()
    {
        switch (pclass)
        {
            case charClass.Paladin:
                vitality += 4;
                strength += 2;
                religion += 4;
                agility -= 2;
                intelligence -= 1;
                luck += 2;
                break;

            case charClass.Assassin:
                agility += 4;
                luck += 2;
                strength += 1;
                vitality -= 3;
                intelligence -= 1;
                mind -= 2;

                break;

            case charClass.Tank:
                vitality += 5;
                strength += 3;
                intelligence -= 3;
                mind -= 1;
                agility -= 3;
                break;

            case charClass.Cleric:
                intelligence += 3;
                mind += 4;
                religion += 2;
                vitality -= 2;
                agility += 1;
                break;

            case charClass.Fighter:
                strength += 4;
                agility += 2;
                vitality += 2;
                mind -= 2;
                intelligence -= 2;
                break;

            case charClass.Priest:
                vitality -= 2;
                intelligence += 2;
                mind += 3;
                religion += 4;
                strength -= 2;
                luck += 1;
                break;

            case charClass.Nitwit:

                strength += 1;
                intelligence -= 1;
                religion -= 1;
                agility += 1;
                break;

            case charClass.Cultist:

                intelligence -= 2;
                mind += 3;
                agility += 1;
                strength -= 2;
                vitality -= 1;
                religion += 4;
                luck += 1;

                break;
        }
    }

    public void ResetClassModifiers()
    {

        vitality = 6;
        intelligence = 6;
        mind = 6;
        strength = 6;
        agility = 6;
        luck = 6;
        religion = 6;


    }

}
