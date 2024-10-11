using TSI.Storages;

public class SlotSwitcher
{
    public Slot Slot { get; private set; }

    private readonly Inventory _inventory;

    public bool TrySwitch()
    {
        var slot = _inventory;

        if (slot == null)
        {
            return false;
        }

        //Switch(slot);

        return true;
    }

    private void Switch(Slot newSlot)
    {
        Slot = newSlot;
    }
}