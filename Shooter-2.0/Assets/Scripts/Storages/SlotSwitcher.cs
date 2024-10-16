using System;
using System.Linq;
using TSI.Item;
using UnityEngine;

namespace TSI.Storages
{
    public class SlotSwitcher
    {
        public Slot SelectedSlot { get; private set; }
        public BaseItem SelectedItem { get; private set; }

        private readonly HotSlot[] _hotSlots;

        public event Action SlotSwitched;

        public SlotSwitcher(HotSlot[] hotSlots)
        {
            _hotSlots = hotSlots;
        }

        public bool TrySwitch()
        {
            var slot = _hotSlots.FirstOrDefault(slot => Input.GetKeyDown(slot.Key));

            if (slot == null)
                return false;

            Switch(slot);

            return true;
        }

        private void Switch(Slot slot)
        {
            SelectedSlot = slot;
            SelectedItem = ItemCache.Instance.Get(slot.Stack.Item);

            SlotSwitched?.Invoke();
        }
    }
}