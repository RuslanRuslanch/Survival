using TSI.Drop;

namespace TSI.Factory
{
    public class DropFactory : BaseFactory<BaseDrop>
    {
        public override void Despawn(BaseDrop obj)
        {
            throw new System.NotImplementedException();
        }

        public override BaseDrop[] Spawn(BaseDrop obj, int count)
        {
            throw new System.NotImplementedException();
        }

        public override BaseDrop Spawn(BaseDrop obj)
        {
            throw new System.NotImplementedException();
        }
    }
}