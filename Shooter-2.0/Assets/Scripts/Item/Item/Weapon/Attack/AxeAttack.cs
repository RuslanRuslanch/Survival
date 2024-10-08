public class AxeAttack : WeaponAttack
{
    private readonly WeaponRaycastFinder _finder;
    private readonly Axe _axe;

    public AxeAttack(float damage, float rate, WeaponRaycastFinder finder, Axe axe) : base(damage, rate)
    {
        _finder = finder;
        _axe = axe;
    }

    public override bool TryAttack()
    {
        if (CanAttack == false)
        {
            return false;
        }
        if (Input.Player.Attack.IsPressed() == false)
        {
            return false;
        }

        Attack();

        return true;
    }

    protected override void Attack()
    {
        WaitDelay();

        var hits = _finder.GetHits();

        foreach (var hit in hits)
        {
            if (hit.collider.TryGetComponent(out IWeaponVisitor visitor) == false)
            {
                continue;
            }

            visitor.Visit(_axe, hit);
        }
    }
}