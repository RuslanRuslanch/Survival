using System;
using UnityEngine;

public abstract class Resource : HealthEntity
{
    [Header("Resource")]
    [SerializeField] private byte _endurance;
    [SerializeField, Min(0)] private int _amount;

    public Action ResourceMined;

    public byte Endurance => _endurance;
    public float Amount => _amount;

    public abstract void Extract();
}
