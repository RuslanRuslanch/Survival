using UnityEngine;

namespace TSI.Drop
{
    public class DropPicker
    {
        private readonly Transform _cameraTransform;
        private readonly DropPickerParameters _parameters;

        private Ray Ray => new Ray(_cameraTransform.position, _cameraTransform.forward);
        private PlayerInput Input => AppContext.Instance.PlayerInput;

        public DropPicker(DropPickerParameters parameters)
        {
            _cameraTransform = Camera.main.transform;

            _parameters = parameters;
        }

        public bool TryPick()
        {
            if (Input.Player.Use.IsPressed() == false)
                return false;

            if (Physics.SphereCast(Ray, _parameters.CheckRadius, out var hit, _parameters.MaxRayDistance, _parameters.SearchLayers) == false)
                return false;

            if (hit.collider.TryGetComponent(out IPickable pickable) == false)
                return false;

            Pick(pickable);

            return true;
        }

        private void Pick(IPickable pickable)
        {
            pickable.TryPick(_parameters.Player);

            Logger.Log("Item picking");
        }
    }
}