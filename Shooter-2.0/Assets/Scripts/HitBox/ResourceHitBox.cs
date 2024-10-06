using UnityEngine;

public class ResourceHitBox : HitBox
{
    [SerializeField] private Resource _resource;

    public override void Visit(WeaponRaycastAttack attack)
    {
        base.Visit(attack);

        _resource.Extract();
    }
}