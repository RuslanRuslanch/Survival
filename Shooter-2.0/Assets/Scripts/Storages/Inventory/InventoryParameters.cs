using System;
using TSI.Item;
using TSI.Storage;
using UnityEngine;

[Serializable]
public class InventoryParameters
{
    [SerializeField] private Slot[] _allSlots;
    [SerializeField] private HotSlot[] _hotSlots;
    [Space]
    [SerializeField] private ItemStackInspector[] _startItems;

    public Slot[] AllSlots => _allSlots;
    public HotSlot[] HotSlots => _hotSlots;
    public ItemStackInspector[] StartItems => _startItems;
}