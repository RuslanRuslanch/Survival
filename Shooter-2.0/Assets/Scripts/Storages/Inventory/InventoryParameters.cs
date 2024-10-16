using System;
using TSI.Storages;
using UnityEngine;

[Serializable]
public class InventoryParameters
{
    [SerializeField] private Slot[] _allSlots;
    [SerializeField] private HotSlot[] _hotSlots;

    public Slot[] AllSlots => _allSlots;
    public HotSlot[] HotSlots => _hotSlots;
}