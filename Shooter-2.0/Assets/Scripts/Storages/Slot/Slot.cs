using System;
using TSI.Item;
using UnityEngine;

namespace TSI.Storage
{
    public class Slot : MonoBehaviour
    {
        public ItemStack Stack { get; private set; }

        public bool IsFree => Stack == null;

        public event Action ValueChanged;
        public event Action ValueOver;

        public bool TryAdd(ItemStack stack)
        {
            if (IsFree)
            {
                Add(stack);

                return true;
            }

            if (stack.Item != Stack.Item || stack.Amount + Stack.Amount > Stack.Item.StackSize)
            {
                return false;
            }

            Add(stack);

            return true;
        }

        public bool TryTake(ItemStack stack)
        {
            if (IsFree)
            {
                return false;
            }

            if (stack.Item != Stack.Item || Stack.Amount - stack.Amount < 0)
            {
                return false;
            }

            Take(stack);

            return true;
        }

        private void Add(ItemStack stack)
        {
            if (IsFree)
            {
                Stack = stack;
            }
            else
            {
                Stack += stack;
            }

            ValueChanged?.Invoke();
        }

        private void Take(ItemStack stack)
        {
            Stack -= stack;

            ValueChanged?.Invoke();

            if (Stack.Amount == 0)
            {
                ValueOver?.Invoke();
            }
        }
    }
}