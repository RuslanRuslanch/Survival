using UnityEngine;
using TSI.Item;
using System.Linq;

namespace TSI.Storages
{
    public class Inventory : Storage
    {
        public readonly HotSlot[] HotSlots;

        public Inventory(HotSlot[] hotSlots, Slot[] slots) : base(slots)
        {
            HotSlots = hotSlots;
        }

        public BaseItem GetHotSlot(KeyCode key)
        {
            var item = HotSlots.FirstOrDefault(slot => slot.Key == key).Stack.Item;

            return ItemCache.Instance.Get(item);
        }
    }
}