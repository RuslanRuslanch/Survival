using System;
using UnityEngine;

namespace TSI.Entities
{
    [Serializable]
    public class GroundMovementData : MovementData
    {
        [SerializeField] private CharacterController _controller;
        [Space]
        [SerializeField, Min(0f)] private float _walkSpeed;
        [SerializeField, Min(0f)] private float _runSpeed;
        [SerializeField, Min(0f)] private float _jumpForce;
        [Space]
        [SerializeField] private Vector3 _gravity;

        public CharacterController Controller => _controller;

        public Vector3 Gravity => _gravity;

        public float WalkSpeed => _walkSpeed;
        public float RunSpeed => _runSpeed;
        public float JumpForce => _jumpForce;
    }
}