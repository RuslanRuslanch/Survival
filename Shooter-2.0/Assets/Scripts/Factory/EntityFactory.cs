using TSI.Entity;

namespace TSI.Factory
{
    public class EntityFactory : BaseFactory<Entity.Entity>
    {
        public override void Despawn(Entity.Entity entity)
        {
            entity.Deinitialize();

            Destroy(entity.gameObject);

            Pop(entity);
        }

        public override Entity.Entity[] Spawn(Entity.Entity entity, int count)
        {
            var entities = new Entity.Entity[count];

            for (int i = 0; i < count; i++)
            {
                entities[i] = Instantiate(entity);

                entities[i].Initialize();

                Push(entities[i]);
            }

            return entities;
        }

        public override Entity.Entity Spawn(Entity.Entity obj)
        {
            return Spawn(obj, 1)[0];
        }
    }
}