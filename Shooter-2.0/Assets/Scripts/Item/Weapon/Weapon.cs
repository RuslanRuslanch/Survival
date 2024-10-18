using TSI.Item;
using UnityEngine;

public abstract class Weapon : BaseItem
{
    [Header("Weapon")]
    [SerializeField, Min(0f)] private float _damage;
    [SerializeField, Min(0f)] private float _maxDistance;
    [SerializeField, Min(0f)] private float _rate;

    public float Damage => _damage;
    public float MaxDistance => _maxDistance;
    public float Rate => _rate;
}