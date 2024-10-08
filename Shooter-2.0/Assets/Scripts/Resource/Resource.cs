using System;
using UnityEngine;

public abstract class Resource : HealthEntity
{
    [Header("Resource")]
    [SerializeField] private ResourceType _type;
    [Space]
    [SerializeField] private byte _endurance;
    [SerializeField, Min(0)] private int _amount;

    public Action ResourceMined;

    public ResourceType Type => _type;
    public byte Endurance => _endurance;
    public float Amount => _amount;

    public abstract void Extract();
}
