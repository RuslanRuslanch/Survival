using UnityEngine;

namespace TSI.BuildSystem
{
    public class BuildingUser
    {
        private readonly Transform _cameraTransform;

        private readonly float _useDistance;
        private readonly LayerMask _searchLayers;

        private readonly PlayerInput _input;

        private Ray Ray => new Ray(_cameraTransform.position, _cameraTransform.forward);

        public BuildingUser(PlayerInput input, float useDistance, LayerMask searchLayers)
        {
            _cameraTransform = Camera.main.transform;

            _useDistance = useDistance;
            _searchLayers = searchLayers;
            _input = input;
        }

        public bool TryUse()
        {
            if (_input.Player.Use.IsPressed() == false)
            {
                return false;
            }
            if (Physics.Raycast(Ray, out var hit, _useDistance, _searchLayers) == false)
            {
                return false;
            }
            if (hit.collider.TryGetComponent(out IUsable usable) == false)
            {
                return false;
            }

            Use(usable);

            return true;
        }

        private void Use(IUsable usable)
        {
            usable.TryUse();
        }
    }
}