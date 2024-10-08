using UnityEngine;

public interface IWeaponVisitor
{
    public void Visit(Axe axe, RaycastHit hit);
}