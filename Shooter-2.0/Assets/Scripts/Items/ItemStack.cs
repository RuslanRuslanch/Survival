using System;

namespace TSI.Items
{
    public class ItemStack
    {
        public readonly ItemInfo Item;
        public readonly int Amount;

        public ItemStack(ItemInfo item, int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            if (item == null)
            {
                throw new NullReferenceException(nameof(item));
            }

            Item = item;
            Amount = amount;
        }
    }
}
