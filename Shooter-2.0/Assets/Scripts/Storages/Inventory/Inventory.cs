using System.Linq;
using TSI.Item;
using UnityEngine;

namespace TSI.Storage
{
    public class Inventory : Storage
    {
        public readonly HotSlot[] HotSlots;

        public Inventory(HotSlot[] hotSlots, Slot[] slots) : base(slots)
        {
            HotSlots = hotSlots;
        }

        public Inventory(ItemStackInspector[] startItems, HotSlot[] hotSlots, Slot[] slots) : base(slots, startItems)
        {
            HotSlots = hotSlots;
        }

        public Slot GetHotSlot(KeyCode key)
        {
            return HotSlots.FirstOrDefault(slot => slot.HotKey == key);
        }
    }
}