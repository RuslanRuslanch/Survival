using System;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int Amount { get; private set; }
    public ItemInfo Item { get; private set; }

    public bool IsFree => Item == null;

    public event Action SlotCleared;
    public event Action SlotChanged;

    public bool TryAdd(ItemStack stack)
    {
        if ((Amount + stack.Amount) > Item.MaxAmount)
        {
            return false;
        }

        Add(stack);

        return true;
    }

    public bool TryTake(ItemStack stack)
    {
        if (IsFree)
        {
            return false;
        }
        if ((Amount - stack.Amount) < 0)
        {
            return false;
        }

        Take(stack);

        return true;
    }

    private void Add(ItemStack stack)
    {
        if (IsFree)
        {
            Item = stack.Item;
        }

        Amount += stack.Amount;

        SlotChanged?.Invoke();
    }

    private void Take(ItemStack stack)
    {
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
}