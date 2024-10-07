using UnityEngine;

public class ResourceHitBox : HitBox
{
    [SerializeField] private Resource _resource;

    public override void Visit(WeaponRaycastAttack attack)
    {
        if (attack.Power < _resource.Endurance)
        {
            return;
        }

        base.Visit(attack);

        _resource.Extract();
    }
}