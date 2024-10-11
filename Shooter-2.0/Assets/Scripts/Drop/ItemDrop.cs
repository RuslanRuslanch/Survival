using TSI.Entities.Character;

namespace TSI.Drop
{
    public class ItemDrop : DropBase
    {
        public override bool TryPick(Player player)
        {
            if (player.Inventory.TryAdd(Stack) == false)
            {
                print("Item drop pick failed");

                return false;
            }

            Pick();

            return true;
        }

        public override void Pick()
        {
            print("Item drop picked");

            DropPicked?.Invoke();
        }
    }
}