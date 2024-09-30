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
            Add(stack);
        }
    }

    public void Add(ItemStack stack)
    {
        var allegedSlot = GetSlotForAdd(stack);

        var currentSlot = allegedSlot == null ? GetFreeSlot() : allegedSlot;

        if (currentSlot == null)
        {
            return;
        }

        currentSlot.Add(stack);
    }

    public void Take(ItemStack stack)
    {
        foreach (var slot in _slots)
        {
            if (slot.IsFree)
            {
                continue;
            }

            if (slot.CanTake(stack.Amount) == false)
            {
                continue;
            }

            slot.Remove(stack);
            return;
        }
    }

    private Slot GetFreeSlot()
    {
        return _slots.FirstOrDefault(slot => slot.IsFree);
    }

    private Slot GetSlotForAdd(ItemStack stack)
    {
        return _slots.FirstOrDefault(slot => slot.Item == stack.Item && slot.CanAdd(stack.Amount));
    }

    private Slot GetSlotPerStack(ItemStack stack)
    {
        return _slots.FirstOrDefault(slot => slot.Item == stack.Item);
    }
}