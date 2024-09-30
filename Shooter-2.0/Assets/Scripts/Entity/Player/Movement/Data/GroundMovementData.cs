using UnityEngine;

public class GroundMovementData : MovementData
{
    public readonly CharacterController Controller;

    public readonly Vector3 Gravity;

    public readonly float WalkSpeed;
    public readonly float RunSpeed;
    public readonly float JumpForce;

    public GroundMovementData(Transform transform, CharacterController controller, Vector3 gravity, float walkSpeed, float runSpeed, float jumpForce) : base(transform)
    {
        Controller = controller;

        Gravity = gravity;

        RunSpeed = runSpeed;
        WalkSpeed = walkSpeed;
        JumpForce = jumpForce;
    }
}