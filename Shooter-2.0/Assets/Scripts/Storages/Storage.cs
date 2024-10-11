using TSI.Items;

namespace TSI.Storages
{
    public class Storage
    {
        protected Slot[] AllSlots { get; private set; }

        public Storage(Slot[] allSlots)
        {
            AllSlots = allSlots;
        }

        public bool TryAdd(ItemStack stack)
        {
            foreach (var slot in AllSlots)
            {
                if (slot.IsFree)
                {
                    slot.TryAdd(stack);

                    return true;
                }

                var succesfullAdd = slot.TryAdd(stack);

                if (succesfullAdd == false)
                {
                    continue;
                }

                return true;
            }

            return false;
        }

        public bool TryTake(ItemStack stack)
        {
            foreach (var slot in AllSlots)
            {
                var succesfullTake = slot.TryTake(stack);

                if (succesfullTake == false)
                {
                    continue;
                }

                return true;
            }

            return false;
        }

        public Slot GetSlot(ItemInfo searchItem)
        {
            foreach (var slot in AllSlots)
            {
                if (slot.IsFree || slot.Item != searchItem)
                {
                    continue;
                }

                return slot;
            }

            return null;
        }
    }
}