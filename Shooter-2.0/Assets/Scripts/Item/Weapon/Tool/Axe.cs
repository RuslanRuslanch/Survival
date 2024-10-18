public class Axe : Weapon
{
    public override bool TryUse()
    {
        Use();

        return true;
    }

    public override void Use()
    {
        print("Axe using");
    }
}
