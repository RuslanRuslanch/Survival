using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Item.Weapon.Attack
{
    public class WeaponRaycastFinder : ITargetFinder
    {
        private readonly Transform _cameraTransform;

        private readonly int _tryCount;

        private readonly bool _useSpread;
        private readonly float _spreadFactor;

        private readonly float _maxRayDistance;
        private readonly LayerMask _searchLayers;

        public WeaponRaycastFinder(int tryCount, bool useSpread, float spreadFactor, float maxRayDistance, LayerMask searchLayers)
        {
            _cameraTransform = Camera.main.transform;

            _tryCount = tryCount;
            _useSpread = useSpread;
            _spreadFactor = spreadFactor;

            _maxRayDistance = maxRayDistance;
            _searchLayers = searchLayers;
        }

        public IDamageable[] Find()
        {
            var targets = new List<IDamageable>();

            for (int i = 0; i < _tryCount; i++)
            {
                var spread = _useSpread ? GetSpread() : Vector3.zero;

                var ray = new Ray(_cameraTransform.position, _cameraTransform.forward + spread);

                if (Physics.Raycast(ray, out var hit, _maxRayDistance, _searchLayers) == false)
                    continue;

                if (hit.collider.TryGetComponent(out IDamageable damageable) == false)
                    continue;

                targets.Add(damageable);
            }

            return targets.ToArray();
        }

        private Vector3 GetSpread()
        {
            return new Vector3()
            {
                x = Random.Range(-_spreadFactor, _spreadFactor),
                y = Random.Range(-_spreadFactor, _spreadFactor),
                z = Random.Range(-_spreadFactor, _spreadFactor),
            };
        }
    }
}