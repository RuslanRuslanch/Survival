using UnityEngine;

public class GroundMovementLogic : MovementLogic<GroundMovementData>
{
    private float CurrentSpeed => Input.Player.Run.IsPressed() ? Data.RunSpeed : Data.WalkSpeed;

    private Vector3 _direction = Vector3.zero;

    public GroundMovementLogic(GroundMovementData data, PlayerInput input) : base(data, input)
    {
    }

    public override void Update()
    {
        TryJump();
        TryMove();

        ApplyGravity();
        ApplyMove();
    }

    private bool TryJump()
    {
        bool tryJump = Input.Player.Jump.IsPressed();

        if (tryJump == false)
        {
            return false;
        }
        if (Data.Controller.isGrounded == false)
        {
            return false;
        }

        Jump();

        return true;
    }

    private bool TryMove()
    {
        Vector2 inputValue = Input.Player.Move.ReadValue<Vector2>();

        if (inputValue == Vector2.zero)
        {
            if (Data.Controller.isGrounded == false)
            {
                return false;
            }

            _direction.x = 0f;
            _direction.z = 0f;

            return false;
        }

        Move(inputValue);

        return true;
    }

    private void Jump()
    {
        _direction.y = Data.JumpForce;
    }

    private void Move(Vector2 inputValue)
    {
        Vector3 worldDirection = new Vector3(inputValue.x, 0f, inputValue.y);

        worldDirection = Data.Transform.TransformDirection(worldDirection) * CurrentSpeed;

        _direction.x = worldDirection.x;
        _direction.z = worldDirection.z;
    }

    private void ApplyMove()
    {
        Data.Controller.Move(_direction * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        _direction += Data.Gravity * Time.deltaTime;
    }
}