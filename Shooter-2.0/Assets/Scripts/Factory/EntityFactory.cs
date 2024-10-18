using TSI.Entity;

namespace TSI.Factory
{
    public class EntityFactory : BaseFactory<BaseEntity>
    {
        public override void Despawn(BaseEntity entity)
        {
            entity.Deinitialize();

            Destroy(entity.gameObject);

            Pop(entity);
        }

        public override BaseEntity[] Spawn(BaseEntity entity, int count)
        {
            var entities = new BaseEntity[count];

            for (int i = 0; i < count; i++)
            {
                entities[i] = Instantiate(entity);

                entities[i].Initialize();

                Push(entities[i]);
            }

            return entities;
        }

        public override BaseEntity Spawn(BaseEntity obj)
        {
            return Spawn(obj, 1)[0];
        }
    }
}