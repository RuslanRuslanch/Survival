using System;
using UnityEngine;

namespace TSI.Entities
{
    [Serializable]
    public class CameraMovementData : MovementData
    {
        public const float MaxRotationX = 90f;
        public const float MinRotationX = -MaxRotationX;

        [SerializeField, Min(0f)] private float _sensivity;
        [SerializeField] private Transform _cameraTransform;

        public float Sensivity => _sensivity;
        public Transform CameraTransform => _cameraTransform;
    }
}