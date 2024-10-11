using TSI.Entities;
using TSI.Entities.Character;
using System;
using UnityEngine;
using TSI.Items;

namespace TSI.Drop
{
    public abstract class DropBase : Entity, IPickable
    {
        [Header("Stack")]
        [SerializeField] private ItemStack _stack;

        public ItemStack Stack => _stack;

        public Action DropPicked;

        public abstract bool TryPick(Player player);
        public abstract void Pick();
    }
}