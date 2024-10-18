using TSI.Item;
using TSI.Storage;

public interface IStorage
{
    public bool TryAdd(ItemStack stack);
    public bool TryTake(ItemStack stack);

    public Slot Get(ItemInfo info);
}
