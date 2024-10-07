public interface IWeaponVisitor
{
    public void Visit(WeaponRaycastAttack attack);
    public void Visit(WeaponOverlapAttack attack);
}