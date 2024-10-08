using System;
using UnityEngine;

public class HitBox : MonoBehaviour, IWeaponVisitor
{
    [Header("Entity")]
    [SerializeField] private GameObject _decal;
    [Space]
    [SerializeField] private HealthEntity _entity;

    public virtual void Visit(Axe axe, RaycastHit hit)
    {
        ApplyDamage(axe.Attack, 1f);
        //SpawnDecal(hit);
    }

    protected void ApplyDamage(AxeAttack attack, float multiplayer)
    {
        if (multiplayer < 0f)
        {
            throw new ArgumentOutOfRangeException(nameof(multiplayer));
        }

        _entity.Health.TryTake(attack.Damage * multiplayer);
    }

    protected void SpawnDecal(RaycastHit hit)
    {
        Instantiate(_decal, hit.point, Quaternion.LookRotation(hit.normal));
    }
}
