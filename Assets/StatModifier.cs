using System.Collections.Generic;

public enum StatmodType
{

    Flat,
    Percent,

}
public class StatModifier
{
    public readonly float Value;
    public readonly StatmodType Type;
    public readonly int Order;

    public StatModifier(float value, StatmodType type, int order)
    {

        Value = value;
        Type = type;
        Order = order; 
    }

    public StatModifier(float value, StatmodType type) : this (value, type, (int)type) { }
 

}
