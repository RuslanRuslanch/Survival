using System;
using UnityEngine;

public class EntityFactory : BaseFactory<Entity>
{
    public override void Despawn(Entity entity)
    {
        if (entity == null)
        {
            throw new NullReferenceException(nameof(entity));
        }

        entity.OnDespawn();

        _pool.Remove(entity);

        Destroy(entity.gameObject);
    }

    public override Entity[] Spawn(Entity entity, Vector3 position, int count)
    {
        if (entity == null)
        {
            throw new NullReferenceException(nameof(entity));
        }
        if (count < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        Entity[] objects = new Entity[count];

        for (int i = 0; i < count; i++)
        {
            var spawnedEntity = Instantiate(entity, position, Quaternion.identity);

            spawnedEntity.OnSpawn();
            _pool.Add(spawnedEntity);

            objects[i] = spawnedEntity;
        }

        return objects;
    }

    public override Entity Spawn(Entity obj, Vector3 position)
    {
        return Spawn(obj, position, 1)[0];
    }
}