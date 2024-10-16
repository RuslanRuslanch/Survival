using UnityEngine;

namespace TSI.Storages
{
    public class HotSlot : Slot
    {
        public readonly KeyCode Key;

        public HotSlot(KeyCode key)
        {
            Key = key;
        }
    }
}