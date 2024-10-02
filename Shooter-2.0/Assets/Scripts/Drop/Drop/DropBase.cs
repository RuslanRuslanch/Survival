using System;
using UnityEngine;

public abstract class DropBase : Entity
{
    [Header("Stack")]
    [SerializeField] private ItemStack _stack;

    public ItemStack Stack => _stack;

    public event Action DropPicked;

    public abstract bool TryPick(Player player);

    protected virtual void Pick()
    {
        DropPicked?.Invoke();
    }
}