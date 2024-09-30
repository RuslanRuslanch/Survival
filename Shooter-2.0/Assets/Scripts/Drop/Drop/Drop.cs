using System;
using UnityEngine;

public abstract class Drop : Entity
{
    [SerializeField] private ItemStack _stack;

    public ItemStack Stack => _stack;

    public event Action DropPicked;

    protected abstract void Pick();
    public abstract bool TryPick();
}