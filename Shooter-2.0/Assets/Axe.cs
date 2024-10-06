using UnityEngine;

public class Axe : Weapon
{
    private WeaponRaycastAttack _attack;

    [SerializeField] private LayerMask _searchLayers;

    private void Awake()
    {
        _attack = new WeaponRaycastAttack(10f, 1f, 10f, _searchLayers, 1, true, 0f);
    }
}
