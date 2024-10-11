using System;
using TSI.Entities.Character;
using UnityEngine;

namespace TSI.Drop
{
    public class DropPicker
    {
        private readonly Transform _cameraTransform;
        private readonly Player _player;

        private readonly float _maxDistance;
        private readonly LayerMask _searchLayers;

        public event Action DropPicked;
        public event Action DropSelected;

        private Ray Ray => new Ray(_cameraTransform.position, _cameraTransform.forward);

        public DropPicker(Player player, float maxDistance, LayerMask searchLayers)
        {
            _maxDistance = maxDistance;
            _searchLayers = searchLayers;
            _player = player;

            _cameraTransform = Camera.main.transform;
        }

        public bool TryPick()
        {
            if (_player.Input.Player.Use.IsPressed() == false)
            {
                return false;
            }
            if (Physics.Raycast(Ray, out var hit, _maxDistance, _searchLayers) == false)
            {
                return false;
            }
            if (hit.collider.TryGetComponent(out DropBase drop) == false)
            {
                return false;
            }

            drop.TryPick(_player);

            DropPicked?.Invoke();

            return true;
        }
    }
}