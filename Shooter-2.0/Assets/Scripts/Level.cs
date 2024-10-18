using TSI.Spawners;
using UnityEngine;

namespace TSI
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private EntitySpawner[] _spawners;

        public void Initialize()
        {
            foreach (var spawner in _spawners)
                spawner.Initialize();
        }
    }
}