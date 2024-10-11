using System.Collections;
using UnityEngine;
using TSI.Factory;

namespace TSI.Entities
{
    public class EntitySpawner : MonoBehaviour
    {
        [SerializeField] private Entity _prefab;
        [Space]
        [SerializeField] private SpawnType _spawnType;
        [SerializeField] private InvokeType _invokeType;
        [Space]
        [SerializeField] private Transform[] _spawnpoints;
        [Space]
        [SerializeField, Min(1)] private int _count;
        [SerializeField, Min(0f)] private float _delay;

        private void Start()
        {
            if (_invokeType != InvokeType.OnStart)
            {
                return;
            }

            if (_spawnType == SpawnType.Single)
            {
                SpawnSingle();
            }
            else if (_spawnType == SpawnType.Period)
            {
                StartSpawnLoop();
            }
        }

        private IEnumerator SpawnLoop()
        {
            var wait = new WaitForSeconds(_delay);

            while (true)
            {
                Spawn();

                yield return wait;
            }
        }

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            for (int j = 0; j < _spawnpoints.Length; j++)
            {
                for (int i = 0; i < _count; i++)
                {
                    EntityFactory.Instance.Spawn(_prefab, _spawnpoints[j].position);
                }
            }
        }

        public void SpawnSingle()
        {
            Spawn();

            Destroy(gameObject);
        }

        private void StartSpawnLoop()
        {
            StartCoroutine(SpawnLoop());
        }

        private enum InvokeType : byte
        {
            OnStart,
            Manualy
        }

        private enum SpawnType : byte
        {
            Single,
            Period
        }
    }
}