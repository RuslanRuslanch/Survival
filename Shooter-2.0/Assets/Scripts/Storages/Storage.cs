using System;
using System.Linq;
using TSI.Item;

namespace TSI.Storage
{
    public class Storage : IStorage
    {
        public bool IsOpened { get; private set; }

        public readonly Slot[] Slots;

        public event Action AddingFailed;
        public event Action TakingFailed;

        public event Action StorageOpened;
        public event Action StorageClosed;

        public Storage(Slot[] slots)
        {
            Slots = slots;

            Close();
        }

        public Storage(Slot[] slots, ItemStackInspector[] startItems)
        {
            Slots = slots;

            AddStartItems(startItems);
            Close();
        }

        public void Open()
        {
            IsOpened = true;

            StorageOpened?.Invoke();
        }

        public void Close()
        {
            IsOpened = false;

            StorageClosed?.Invoke();
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

        private void AddStartItems(ItemStackInspector[] startItems)
        {
            foreach (var item in startItems.Select(view => view.Stack))
            {
                TryAdd(item);
            }
        }
    }
}