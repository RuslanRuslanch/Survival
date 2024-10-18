using UnityEngine;
using TSI.HP;

namespace TSI.Entity
{
    public class HealthEntity : BaseEntity, IHealthable
    {
        public Health Health { get; private set; }

        [field: SerializeField, Min(0f)] public float MaxHealth { get; private set; }
        [field: SerializeField, Min(0f)] public float StartHealth { get; private set; }

        public override void Initialize()
        {
            base.Initialize();

            Health = new Health(StartHealth, MaxHealth);
        }
    }
}