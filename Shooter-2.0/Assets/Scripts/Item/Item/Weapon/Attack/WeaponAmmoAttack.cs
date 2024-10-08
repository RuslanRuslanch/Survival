public abstract class WeaponAmmoAttack : WeaponAttack
{
    protected readonly Ammo _ammo;

    public WeaponAmmoAttack(float damage, float rate, Ammo ammo) : base(damage, rate)
    {
        _ammo = ammo;
    }
}