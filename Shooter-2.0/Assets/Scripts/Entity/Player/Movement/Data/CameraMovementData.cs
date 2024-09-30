using UnityEngine;

public class CameraMovementData : MovementData
{
    public const float MaxRotationX = 90f;
    public const float MinRotationX = -MaxRotationX;

    public readonly float Sensivity;

    public readonly Transform CameraTransform;

    public CameraMovementData(Transform transform, Transform cameraTransform, float sensivity) : base(transform)
    {
        CameraTransform = cameraTransform;

        Sensivity = sensivity;
    }
}