using System;
using TSI.BuildSystem.Buildings;
using TSI.Entities;
using UnityEngine;

namespace TSI.Factory
{
    public class BuildingFactory : BaseFactory<Building>
    {
        public override void Despawn(Building obj)
        {
            Pool.Remove(obj);

            Destroy(obj.gameObject);
        }

        public override Building[] Spawn(Building building, Vector3 position, int count)
        {
            if (building == null)
            {
                throw new NullReferenceException(nameof(building));
            }
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            Building[] objects = new Building[count];

            for (int i = 0; i < count; i++)
            {
                var spawnedEntity = Instantiate(building, position, Quaternion.identity);

                Pool.Add(spawnedEntity);

                objects[i] = spawnedEntity;
            }

            return objects;
        }

        public override Building Spawn(Building obj, Vector3 position)
        {
            return Spawn(obj, position, 1)[0];
        }
    }
}