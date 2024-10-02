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

    protected override void Pick()
    {
        print("Item drop picked");

        base.Pick();
    }
}