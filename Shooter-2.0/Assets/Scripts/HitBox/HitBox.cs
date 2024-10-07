using System;
using UnityEngine;

public class HitBox : MonoBehaviour, IWeaponVisitor
{
    [Header("Entity")]
    [SerializeField] private HealthEntity _entity;

    public virtual void Visit(WeaponRaycastAttack attack)
    {
        print("Raycast attack");

        ApplyDamage(attack, 1f);
    }

    public virtual void Visit(WeaponOverlapAttack attack)
    {
        print("Overlap attack");

        ApplyDamage(attack, 1f);
    }

    protected void ApplyDamage(WeaponAttack attack, float multiplayer)
    {
        if (multiplayer < 0f)
        {
            throw new ArgumentOutOfRangeException(nameof(multiplayer));
        }

        print("Damage applying");
        _entity.Health.TryTake(attack.Damage * multiplayer);
    }
}
