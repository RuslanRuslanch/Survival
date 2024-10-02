using System;

[Serializable]
public struct ItemStack
{
    public ItemInfo Item;
    public int Amount;

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