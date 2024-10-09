using System;

public class Ammo
{
    private int _savedAmmo, _magazineAmmo;

    public readonly int MaxSavedAmmo;
    public readonly int MaxMagazineAmmo;

    public int MagazineAmmo
    {
        get
        {
            return _magazineAmmo;
        }
        private set
        {
            _magazineAmmo = Math.Clamp(SavedAmmo, 0, MaxMagazineAmmo);
        }
    }

    public int SavedAmmo
    {
        get
        {
            return _savedAmmo;
        }
        private set
        {
            _savedAmmo = Math.Clamp(SavedAmmo, 0, MaxSavedAmmo);
        }
    }

    public int TotalAmmo => _savedAmmo + MagazineAmmo;
    public int MaxTotalAmmo => MaxSavedAmmo + MaxMagazineAmmo;

    public bool IsOver => MagazineAmmo == 0f && SavedAmmo == 0f;

    public event Action AmmoChanged;
    public event Action AmmoOver;

    public Ammo(int maxSavedAmmo, int maxMagazineAmmo, int startAmmo)
    {
        MaxSavedAmmo = maxSavedAmmo;
        MaxMagazineAmmo = maxMagazineAmmo;
        MagazineAmmo = startAmmo;
    }

    public bool TryAdd(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        if (TotalAmmo == MaxTotalAmmo)
        {
            return false;
        }

        Add(amount);

        return true;
    }

    public bool TryTake(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        if ((MagazineAmmo - amount) < 0)
        {
            return false;
        }

        Take(amount);

        return true;
    }

    private void Add(int amount)
    {
        var ammoSumma = MagazineAmmo + amount;
        var ammoOffset = ammoSumma - MaxMagazineAmmo;

        var remainsAmmo = Math.Clamp(ammoOffset, 0, MaxTotalAmmo);

        SavedAmmo += remainsAmmo;

        AmmoChanged?.Invoke();
    }

    private void Take(int amount)
    {
        MagazineAmmo -= amount;

        AmmoChanged?.Invoke();

        if (IsOver)
        {
            AmmoOver?.Invoke();
        }
    }
}
