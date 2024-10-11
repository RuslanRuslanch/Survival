using UnityEngine;

public abstract class AmmoView : MonoBehaviour
{
    protected Ammo Ammo { get; private set; }

    public void Init(Ammo ammo)
    {
        Ammo = ammo;
    }

    private void OnEnable()
    {
        Ammo.AmmoChanged += OnChange;
        Ammo.AmmoOver += OnOver;
    }

    private void OnDisable()
    {
        Ammo.AmmoChanged -= OnChange;
        Ammo.AmmoOver -= OnOver;
    }

    protected abstract void OnChange();
    protected abstract void OnOver();
}