using UnityEngine;

public class Axe : Weapon
{
    [Header("Weapon")]
    [SerializeField, Min(0f)] private float _damage;
    [SerializeField, Min(0.1f)] private float _rate;
    [SerializeField, Min(1f)] private float _maxDistance;
    [Space]
    [SerializeField] private byte _power;
    [Space]
    [SerializeField] private byte _attackCount;
    [Space]
    [SerializeField] private bool _useSpread;
    [SerializeField, Min(0f)] private float _spreadFactor;
    [Space]
    [SerializeField] private LayerMask _searchLayers;

    private void Awake()
    {
        new WeaponRaycastAttack(_damage, _rate, _maxDistance, _power, _searchLayers, _attackCount, _useSpread, _spreadFactor);
    }
}
