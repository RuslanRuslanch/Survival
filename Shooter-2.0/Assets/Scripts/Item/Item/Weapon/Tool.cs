using UnityEngine;

public class Tool : Weapon
{
    [Header("Power")]
    [SerializeField] private ResourceType _targetType;
    [SerializeField, Min(0)] private int _power;

    public int Power => _power;
    public ResourceType TargetType => _targetType;
}
