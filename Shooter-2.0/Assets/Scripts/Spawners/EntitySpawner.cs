using TSI.Entity;
using TSI.Factory;

namespace TSI.Spawners
{
    public class EntitySpawner : ObjectSpawner<BaseEntity>
    {
        public override void Initialize()
        {
            if (SpawnPeriod == SpawnPeriod.Single)
                Spawn();
            else
                StartCoroutine(SpawnLoop());
        }

        public override BaseEntity[] Spawn()
        {
            var entities = EntityFactory.Instance.Spawn(Prefab, Count);

            foreach (var entity in entities)
                entity.transform.position = Spawnpoint.position;

            return entities;
        }
    }
}