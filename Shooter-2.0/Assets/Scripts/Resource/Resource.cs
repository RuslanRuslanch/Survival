using System;
using TSI.Entities;
using UnityEngine;

public abstract class Resource : HealthEntity
{
    [Header("Resource")]
    [SerializeField] private ResourceType _type;
    [Space]
    [SerializeField, Min(0)] private int _endurance;
    [SerializeField, Min(0)] private int _amount;

    public Action ResourceMined;

    public ResourceType Type => _type;
    public int Endurance => _endurance;
    public int Amount => _amount;

    public abstract void Extract();
}
