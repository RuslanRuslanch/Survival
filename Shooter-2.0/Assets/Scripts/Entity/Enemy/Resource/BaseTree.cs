namespace TSI.Resource
{
    public class BaseTree : Resource
    {
        public override void Extract()
        {
        }

        public override void TakeDamage(float damage)
        {
            Health.TryTake(damage);

            if (Health.IsDead)
                ResourceMined?.Invoke();
        }

        public override bool TryExtract()
        {
            Extract();

            return true;
        }

        public override bool TryTakeDamage(float damage)
        {
            TakeDamage(damage);

            return true;
        }
    }
}