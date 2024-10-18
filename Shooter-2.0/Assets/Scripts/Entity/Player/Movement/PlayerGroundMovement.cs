using System;
using UnityEngine;

namespace TSI.Character.Movement
{
    public class PlayerGroundMovement : PlayerMovement
    {
        private const float MinRotationX = -MaxRotationX;
        private const float MaxRotationX = 90f;

        private float _rotationX;
        private Vector3 _direction;

        private readonly Transform _characterTransform;
        private readonly Transform _cameraTransform;

        private readonly CharacterController _controller;

        private readonly float _sensivity;

        private float CurrentSpeed => GetCurrentSpeed();

        public PlayerGroundMovement(PlayerMovementParameters parameters, CharacterController controller, Transform characterTransform, Transform cameraTransform) : base(parameters)
        {
            _controller = controller;
            _characterTransform = characterTransform;
            _cameraTransform = cameraTransform;

            Cursor.lockState = CursorLockMode.Locked;
        }

        public override bool TryRotate()
        {
            var delta = Input.Mouse.Delta.ReadValue<Vector2>();

            if (delta == Vector2.zero)
                return false;

            Rotate(delta);

            return true;
        }


        public override bool TryTranslate()
        {
            var direction = Input.Player.Move.ReadValue<Vector2>();

            if (direction == Vector2.zero)
                return false;

            Translate(direction);

            return true;
        }

        private void Translate(Vector2 direction)
        {
            var inputDirection = new Vector3(direction.x, 0f, direction.y);

            inputDirection = _characterTransform.TransformDirection(inputDirection) * CurrentSpeed;

            _controller.Move(inputDirection * Time.deltaTime);
        }

        private void Rotate(Vector2 delta)
        {
            delta *= Parameters.Sensivity * Time.fixedDeltaTime;

            _rotationX -= delta.y;
            _rotationX = Math.Clamp(_rotationX, MinRotationX, MaxRotationX);

            _cameraTransform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
            _characterTransform.Rotate(Vector3.up * (Parameters.RotationSpeed * delta.x));
        }

        private float GetCurrentSpeed()
        {
            return Input.Player.Run.IsPressed() ? Parameters.RunSpeed : Parameters.WalkSpeed;
        }
    }
}