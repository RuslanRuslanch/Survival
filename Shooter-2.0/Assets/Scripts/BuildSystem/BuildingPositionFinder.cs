using UnityEngine;

namespace TSI.BuildSystem
{
    public class BuildingPositionFinder
    {
        private readonly float _maxDistance;
        private readonly LayerMask _searchLayers;
        private readonly Transform _cameraTransform;

        public BuildingPositionFinder(float maxDistance, LayerMask searchLayers)
        {
            _maxDistance = maxDistance;
            _searchLayers = searchLayers;

            _cameraTransform = Camera.main.transform;
        }

        public RaycastHit GetPosition()
        {
            Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);

            Physics.Raycast(ray, out var hit, _maxDistance, _searchLayers);

            return hit;
        }
    }
}