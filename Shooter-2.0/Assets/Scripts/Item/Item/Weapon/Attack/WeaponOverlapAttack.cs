using UnityEngine;

public class WeaponOverlapAttack : WeaponAttack
{
    private readonly Transform _center;

    public WeaponOverlapAttack(float damage, float rate, float radius, byte power, Transform center) : base(damage, rate, radius, power)
    {
        _center = center;
    }

    public override bool TryAttack()
    {
        throw new System.NotImplementedException();
    }

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }

    private Collider[] GetColliders()
    {
        return Physics.OverlapSphere(_center.position, MaxDistance);
    }

    protected virtual void Accept(IWeaponVisitor visitor) => visitor.Visit(this);
}