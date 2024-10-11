using TSI.Items;

namespace TSI.Storages
{
    public class Inventory : Storage
    {
        private readonly Slot[] _hotSlots;

        public Inventory(ItemStackInspector[] startItems, Slot[] allSlots, Slot[] hotSlots) : base(allSlots)
        {
            _hotSlots = hotSlots;

            AddStartItems(startItems);
        }

        private void AddStartItems(ItemStackInspector[] items)
        {
            if (items == null)
            {
                return;
            }

            foreach (var item in items)
            {
                TryAdd(item.Stack);
            }
        }

        public Slot GetHotSlot(int index)
        {
            return _hotSlots[index];
        }
    }
}