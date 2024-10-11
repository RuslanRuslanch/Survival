namespace TSI.BuildSystem.Buildings
{
    public class MineBuilding : UseableBuilding
    {
        public override bool TryUse()
        {
            Use();

            return true;
        }

        public override void Use()
        {
            print("I use minebuilding");
        }
    }
}
