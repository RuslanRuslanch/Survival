using System;
using UnityEngine;

[Serializable]
public class PlayerMovementParameters
{
    [Header("Translate")]
    [SerializeField, Range(0.1f, 5f)] private float _walkSpeed;
    [SerializeField, Range(0.1f, 10f)] private float _runSpeed;
    [SerializeField, Range(0.1f, 10f)] private float _jumpForce;
    [Space]
    [SerializeField, Range(0.1f, 10f)] private float _rotateSpeed;

    [Header("Camera")]
    [SerializeField, Range(0.1f, 100f)] private float _sensivity;

    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float JumpForce => _jumpForce;
    public float RotationSpeed => _rotateSpeed;
    public float Sensivity => _sensivity;
}