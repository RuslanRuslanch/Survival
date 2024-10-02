using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Slot[] _slots;
    [Space]
    [SerializeField] private ItemStack[] _startItems;

    private void Start()
    {
        AddStartItems();
    }

    private void AddStartItems()
    {
        foreach (var stack in _startItems)
        {
            TryAdd(stack);
        }
    }

    public bool TryAdd(ItemStack stack)
    {
        Slot slot = GetSlotForAdd(stack);

        if (slot == null)
        {
            return false;
        }

        slot = GetFreeSlot();

        if (slot == null)
        {
            return false;
        }

        Add(slot, stack);

        return true;
    }

    public bool TryTake(ItemStack stack)
    {
        foreach (var slot in _slots)
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

    public void Add(Slot slot, ItemStack stack)
    {
        slot.TryAdd(stack);
    }

    public void Take(Slot slot, ItemStack stack)
    {
        slot.TryTake(stack);
    }

    private Slot GetFreeSlot()
    {
        return _slots.FirstOrDefault(slot => slot.IsFree);
    }

    private Slot GetSlotForAdd(ItemStack stack)
    {
        return _slots.FirstOrDefault(slot => slot.Item == stack.Item && slot.TryAdd(stack));
    }

    private Slot GetSlotPerStack(ItemStack stack)
    {
        return _slots.FirstOrDefault(slot => slot.Item == stack.Item);
    }
}