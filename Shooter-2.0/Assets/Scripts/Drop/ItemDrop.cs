using TSI.Character;
using TSI.Item;
using UnityEngine;

namespace TSI.Drop
{
    public class ItemDrop : BaseDrop
    {
        [SerializeField] private ItemStackInspector _stackInspector;

        public ItemStack Stack => _stackInspector.Stack;

        public override void Pick(Player player)
        {
            DropPickSuccess?.Invoke();
        }

        public override bool TryPick(Player player)
        {
            if (player.Inventory.TryAdd(Stack) == false)
                return false;

            Pick(player);

            return true;
        }
    }
}