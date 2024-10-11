using TSI.Items;
using UnityEngine;

public class Weapon : ItemBase
{
    [Header("Weapon")]
    [SerializeField, Min(0f)] private float _damage;
    [SerializeField, Min(0.1f)] private float _rate;
    [SerializeField, Min(1f)] private float _maxDistance;
    [Space]
    [SerializeField] private int _attackCount;
    [Space]
    [SerializeField] private bool _useSpread;
    [SerializeField, Min(0f)] private float _spreadFactor;
    [Space]
    [SerializeField] private LayerMask _searchLayers;

    public float Damage => _damage;
    public float Rate => _rate;
    public float MaxDistance => _maxDistance;
    public int AttackCount => _attackCount;
    public bool UseSpread => _useSpread;
    public float SpreadFactor => _spreadFactor;
    public LayerMask SearchLayers => _searchLayers;
}