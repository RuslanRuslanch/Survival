using System;
using System.Linq;
using TSI.Item;
using UnityEngine;

namespace TSI.Storage
{
    public class SlotSwitcher
    {
        public Slot SelectedSlot { get; private set; }
        public BaseItem SelectedItem { get; private set; }

        private readonly ItemCache _itemCache;
        private readonly HotSlot[] _hotSlots;

        public event Action SlotSwitched;

        public SlotSwitcher(HotSlot[] hotSlots, ItemCache itemCache)
        {
            _hotSlots = hotSlots;
            _itemCache = itemCache;
        }

        public bool TrySwitch()
        {
            var slot = _hotSlots.FirstOrDefault(slot => Input.GetKeyDown(slot.HotKey));

            if (slot == null)
                return false;

            Switch(slot);

            return true;
        }

        private void Switch(Slot slot)
        {
            SelectedSlot = slot;
            SelectedItem = _itemCache.Get(slot.Stack.Item);

            SlotSwitched?.Invoke();
        }
    }
}