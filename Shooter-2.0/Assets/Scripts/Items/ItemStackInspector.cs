using System;
using UnityEngine;

namespace TSI.Items
{
    [Serializable]
    public class ItemStackInspector
    {
        [SerializeField] private ItemInfo _info;
        [SerializeField, Min(1)] private int _amount;

        public ItemStack Stack => new ItemStack(_info, _amount);
    }
}