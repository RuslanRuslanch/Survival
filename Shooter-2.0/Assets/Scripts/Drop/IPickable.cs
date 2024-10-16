using TSI.Character;

public interface IPickable
{
    public bool TryPick(Player player);
    public void Pick(Player player);
}