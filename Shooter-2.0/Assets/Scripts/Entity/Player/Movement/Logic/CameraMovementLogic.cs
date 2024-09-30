using UnityEngine;

public class CameraMovementLogic : MovementLogic<CameraMovementData>
{
    private float _rotationX;

    private Vector2 MouseDelta => Input.Mouse.Delta.ReadValue<Vector2>();

    public CameraMovementLogic(CameraMovementData data, PlayerInput input) : base(data, input)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public override void Update()
    {
        TryRotate();
    }

    private bool TryRotate()
    {
        Vector2 mouseDelta = MouseDelta;

        if (mouseDelta == Vector2.zero)
        {
            return false;
        }

        Rotate(mouseDelta * (Data.Sensivity * Time.fixedDeltaTime));

        return true;
    }

    private void Rotate(Vector2 mouseDelta)
    {
        _rotationX -= mouseDelta.y;
        _rotationX = Mathf.Clamp(_rotationX, CameraMovementData.MinRotationX, CameraMovementData.MaxRotationX);

        Data.Transform.Rotate(Vector3.up * mouseDelta.x);
        Data.CameraTransform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
    }
}