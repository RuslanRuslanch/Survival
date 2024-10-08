using System;

public class Ammo
{
    private int _savedAmmo;

    public readonly int MaxSavedAmmo;
    public readonly int MaxMagazineAmmo;

    public int CurrentAmmo;

    public int SavedAmmo
    {
        get
        {
            return _savedAmmo;
        }
        private set
        {
            _savedAmmo = Math.Clamp(SavedAmmo, 0, MaxTotalAmmo);
        }
    }

    public int TotalAmmo => _savedAmmo + CurrentAmmo;
    public int MaxTotalAmmo => MaxSavedAmmo + MaxMagazineAmmo;
    public bool IsOver => CurrentAmmo == 0f && SavedAmmo == 0f;

    public Ammo(int maxSavedAmmo, int maxMagazineAmmo, int startAmmo)
    {
        MaxSavedAmmo = maxSavedAmmo;
        MaxMagazineAmmo = maxMagazineAmmo;
        CurrentAmmo = startAmmo;
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
        if (TotalAmmo == 0)
        {
            return false;
        }

        Take(amount);

        return true;
    }

    private void Add(int amount)
    {
        var ammoSumma = CurrentAmmo + amount;
        var ammoOffset = ammoSumma - MaxMagazineAmmo;

        var remainsAmmo = Math.Clamp(ammoOffset, 0, MaxTotalAmmo);

        SavedAmmo += remainsAmmo;
    }

    private void Take(int amount)
    {


    }
}