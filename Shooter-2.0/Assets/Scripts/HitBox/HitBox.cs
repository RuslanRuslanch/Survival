using System;
using UnityEngine;

public class HitBox : MonoBehaviour, IWeaponVisitor
{
    [Header("Entity")]
    [SerializeField] private Animal _entity;

    public void Visit()
    {
        throw new NotImplementedException();
    }

    protected void ApplyDamage(WeaponAttack attack, float multiplayer)
    {
        if (multiplayer <= 0f)
        {
            throw new ArgumentOutOfRangeException(nameof(multiplayer));
        }

        _entity.Health.TryTake(attack.Damage * multiplayer);
    }
}
