using TSI.Entities.Character;

public interface IPickable
{
    public bool TryPick(Player player);
    public void Pick();
}