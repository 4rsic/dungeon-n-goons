// using UnityEngine;

using System;
using System.Collections.Generic;

public class CharacterStats
{
    public float baseValue;

    public float val
    {
        get
        {

            if (isDirty)
            {
                _value = CalculateFV();
                isDirty = false;

            }
            return _value;

        }

    }

    private bool isDirty = true;

    private float _value;

    public readonly List<StatModifier> statModifiers;

    public CharacterStats(float BaseValue)
    {

        baseValue = BaseValue;

        statModifiers = new List<StatModifier>();

    }

    private int compareModOrder(StatModifier a, StatModifier b)
    {

        if (a.Order < b.Order)

            return -1;
        else if (a.Order > b.Order)
            return 1;
        return 0;

    }

    public void AddMod(StatModifier modifier)
    {
        isDirty = true;
        statModifiers.Add(modifier);
        statModifiers.Sort();

    }

    public void RemoveMod(StatModifier modifier)
    {
        isDirty = true;
        statModifiers.Remove(modifier);
        statModifiers.Sort();

    }

    private float CalculateFV()
    {

        float fv = baseValue;

        for (int i = 0; i < statModifiers.Count; i++)

        {
            StatModifier modi = statModifiers[i];

            if (modi.Type == StatmodType.Flat)
            {

                fv += modi.Value;

            }
            else if (modi.Type == StatmodType.Percent)
            {

                fv *= 1 + modi.Value;

            }

        }

        return (float)Math.Round(fv, 4);

    }

}
