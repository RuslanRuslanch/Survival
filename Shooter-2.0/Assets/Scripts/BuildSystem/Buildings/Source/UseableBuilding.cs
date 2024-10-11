namespace TSI.BuildSystem.Buildings
{
    public abstract class UseableBuilding : Building, IUsable
    {
        public abstract bool TryUse();
        public abstract void Use();
    }
}