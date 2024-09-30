using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private IMovementLogic _movementLogic, _cameraLogic;

    private PlayerInput _input;

    [Header("Character Movement")]
    [SerializeField, Min(0.1f)] private float _walkSpeed = 3f;
    [SerializeField, Min(0.1f)] private float _runSpeed = 5f;
    [Space]
    [SerializeField, Min(0.1f)] private float _jumpForce = 5f;
    [Space]
    [SerializeField] private Vector3 _gravity = Vector3.up * -9.81f;

    [Header("Camera Movement")]
    [SerializeField] private Transform _cameraTransform;
    [Space]
    [SerializeField, Min(0.1f)] private float _sensivity;

    private void Awake()
    {
        var controller = GetComponent<CharacterController>();

        var movementData = new GroundMovementData(transform, controller, _gravity, _walkSpeed, _runSpeed, _jumpForce);
        var cameraMovementData = new CameraMovementData(transform, _cameraTransform, _sensivity);

        _input = new PlayerInput();

        _cameraLogic = new CameraMovementLogic(cameraMovementData, _input);
        _movementLogic = new GroundMovementLogic(movementData, _input);

    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        _movementLogic.Update();
        _cameraLogic.Update();
    }
}