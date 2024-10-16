using System;
using System.Collections;
using TSI.Factory;
using UnityEngine;

namespace TSI.Entity
{
    public class EntitySpawner : MonoBehaviour
    {
        [SerializeField] private Entity _prefab;
        [Space]
        [SerializeField, Range(1, 100)] private int _count;
        [SerializeField, Range(0f, 1000f)] private float _rate;
        [Space]
        [SerializeField] private SpawnPeriod _spawnPeriod;
        [Space]
        [SerializeField] private Transform _spawnpoint;

        public void Initialize()
        {
            if (_spawnPeriod == SpawnPeriod.Single)
                Spawn();
            else
                StartCoroutine(SpawnLoop());
        }

        private IEnumerator SpawnLoop()
        {
            var delay = new WaitForSeconds(_rate);

            while (true)
            {
                Spawn();

                yield return delay;
            }
        }

        private Entity[] Spawn()
        {
            var entities = EntityFactory.Instance.Spawn(_prefab, _count);

            foreach (var entity in entities)
                entity.transform.position = _spawnpoint.position;

            return entities;
        }

        private enum SpawnPeriod : byte
        {
            Single,
            Periodly,
        }
    }
}