using System;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int Amount { get; private set; }
    public Item Item { get; private set; }

    public bool IsFree => Item == null;

    public event Action SlotCleared;
    public event Action SlotChanged;

    public void Add(ItemStack stack)
    {
        if (IsFree)
        {
            Item = stack.Item;
        }

        Amount += stack.Amount;

        SlotChanged?.Invoke();
    }

    public void Remove(ItemStack stack)
    {
        if (IsFree)
        {
            throw new NullReferenceException(nameof(Item));
        }

        Amount -= stack.Amount;

        SlotChanged?.Invoke();

        if ((Amount - stack.Amount) == 0)
        {
            Clear();
        }
    }

    private void Clear()
    {
        Item = null;
        Amount = 0;

        SlotCleared?.Invoke();
    }

    public bool CanAdd(int amount)
    {
        if (IsFree)
        {
            return true;
        }

        return (Amount + amount) <= Item.Info.MaxAmount;
    }

    public bool CanTake(int amount)
    {
        if (IsFree)
        {
            return false;
        }

        return (Amount - amount) >= 0;
    }
}