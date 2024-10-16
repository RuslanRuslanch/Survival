namespace TSI.Item
{
    public class ItemStack
    {
        public readonly ItemInfo Item;
        public readonly int Amount;

        public ItemStack(ItemInfo item, int amount)
        {
            Item = item;
            Amount = amount;
        }

        public static ItemStack operator +(ItemStack lhs, ItemStack rhs)
        {
            return new ItemStack(lhs.Item, lhs.Amount + rhs.Amount);
        }

        public static ItemStack operator -(ItemStack lhs, ItemStack rhs)
        {
            return new ItemStack(lhs.Item, lhs.Amount - rhs.Amount);
        }
    }
}