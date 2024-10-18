using UnityEngine;

namespace TSI.Storage
{
    public class HotSlot : Slot
    {
        [SerializeField] private KeyCode _hotKey;

        public KeyCode HotKey => _hotKey;
    }
}