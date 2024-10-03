using System;
using UnityEngine;

[Serializable]
public struct FoodSaturations
{
    [Header("Saturations")]
    [SerializeField, Range(0, 100)] private int _food;
    [SerializeField, Range(0, 100)] private int _water;
    [SerializeField, Range(0, 100)] private int _stamina;

    public readonly int Food => _food;
    public readonly int Water => _water;
    public readonly int Stamina => _stamina;
}
