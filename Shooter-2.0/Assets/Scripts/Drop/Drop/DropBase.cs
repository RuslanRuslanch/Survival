using System;
using UnityEngine;

public abstract class DropBase : Entity
{
    [Header("Stack")]
    [SerializeField] private ItemStackInspector _stack;

    public ItemStack Stack => _stack.Stack;

    public event Action DropPicked;

    public abstract bool TryPick(Player player);

    protected virtual void Pick()
    {
        DropPicked?.Invoke();
    }

    // Invoke base.Pick() only on destroy drop gameobject
}