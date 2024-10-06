using System;
using UnityEngine;

[Serializable]
public class ItemStackInspector
{
    [SerializeField] private ItemInfo _item;
    [SerializeField, Min(1)] private int _amount;

    public ItemStack Stack => new ItemStack(_item, _amount);
}