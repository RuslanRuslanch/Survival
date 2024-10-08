public class Axe : Tool
{
    private AxeAttack _attack;

    public AxeAttack Attack => _attack;

    private void Awake()
    {
        var finder = new WeaponRaycastFinder(MaxDistance, UseSpread, SpreadFactor, AttackCount, SearchLayers);

        _attack = new AxeAttack(Damage, Rate, finder, this);
    }

    private void Update()
    {
        _attack.TryAttack();
    }
}
