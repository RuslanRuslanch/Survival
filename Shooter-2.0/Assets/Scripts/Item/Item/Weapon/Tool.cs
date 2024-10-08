using UnityEngine;

public class Tool : Weapon
{
    [Header("Power")]
    [SerializeField] private ResourceType _target;
    [SerializeField] private byte _power;

    public byte Power => _power;
    public ResourceType Target => _target;
}
