public class AmmoReloader
{
    private readonly Ammo _ammo;

    public AmmoReloader(Ammo ammo)
    {
        _ammo = ammo;
    }

    public bool TryReload()
    {
        if (_ammo.SavedAmmo == 0)
        {
            return false;
        }

        Reload();

        return true;
    }

    private void Reload()
    {
        if ((_ammo.SavedAmmo - _ammo.MaxMagazineAmmo) >= 0)
        {
            _ammo.TryAdd(_ammo.MaxMagazineAmmo);
            _ammo.TryTake(_ammo.MaxMagazineAmmo);
        }
        else
        {
            _ammo.TryAdd(_ammo.SavedAmmo);
            _ammo.TryTake(_ammo.SavedAmmo);
        }
    }
}