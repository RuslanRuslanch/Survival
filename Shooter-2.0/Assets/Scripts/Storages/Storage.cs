using System;
using System.Linq;
using TSI.Item;

namespace TSI.Storages
{
    public class Storage : IStorage
    {
        public readonly Slot[] Slots;

        public event Action AddingFailed;
        public event Action TakingFailed;

        public Storage(Slot[] slots)
        {
            Slots = slots;
        }

        public Slot Get(ItemInfo item)
        {
            return Slots.FirstOrDefault(slot => slot.Stack.Item == item);
        }

        public Slot Get(ItemStack stack)
        {
            return Slots.FirstOrDefault(slot => slot.Stack.Item == stack.Item && slot.Stack.Amount + stack.Amount <= stack.Item.StackSize);
        }

        public bool TryAdd(ItemStack stack)
        {
            if (Slots.Length == 0) 
                return false;

            foreach (var slot in Slots)
            {
                var succesfull = slot.TryAdd(stack);

                if (succesfull == false)
                    continue;

                return true;
            }

            AddingFailed?.Invoke();

            return false;
        }

        public bool TryTake(ItemStack stack)
        {
            if (Slots.Length == 0)
                return false;

            foreach (var slot in Slots)
            {
                var succesfull = slot.TryTake(stack);

                if (succesfull == false)
                    continue;

                return true;
            }

            TakingFailed?.Invoke();

            return false;
        }
    }
}