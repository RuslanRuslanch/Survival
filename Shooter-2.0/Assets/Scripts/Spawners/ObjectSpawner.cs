using System.Collections;
using UnityEngine;

namespace TSI.Spawners
{
    public abstract class ObjectSpawner<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T _prefab;
        [Space]
        [SerializeField, Range(1, 100)] private int _count;
        [SerializeField, Range(0f, 1000f)] private float _rate;
        [Space]
        [SerializeField] private SpawnPeriod _spawnPeriod;
        [Space]
        [SerializeField] private Transform _spawnpoint;

        public T Prefab => _prefab;
        public int Count => _count;
        public float Rate => _rate;
        public SpawnPeriod SpawnPeriod => _spawnPeriod;
        public Transform Spawnpoint => _spawnpoint;

        public IEnumerator SpawnLoop()
        {
            var delay = new WaitForSeconds(Rate);

            while (true)
            {
                Spawn();

                yield return delay;
            }
        }

        public abstract void Initialize();
        public abstract T[] Spawn();
    }

    public enum SpawnPeriod : byte
    {
        Single,
        Periodly,
    }
}