using System;
using UnityEngine;

[Serializable]
public struct ItemStack
{
    public Item Item;
    [Min(1)] public int Amount;

    public ItemStack(Item item, int amount)
    {
        Item = item;
        Amount = amount;
    }
}