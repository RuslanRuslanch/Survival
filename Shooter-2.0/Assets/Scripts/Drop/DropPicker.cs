using TMPro;
using UnityEngine;

public class DropPicker : MonoBehaviour
{
    private PlayerInput _input;

    [Header("Inventory")]
    [SerializeField] private Inventory _inventory;

    [Header("Pick UP")]
    [SerializeField] private Player _player;
    [SerializeField] private Camera _camera;
    [Space]
    [SerializeField, Min(0f)] private float _maxDistance;
    [Space]
    [SerializeField] private LayerMask _searchLayers;

    private Ray Ray => _camera.ScreenPointToRay(_input.Mouse.Position.ReadValue<Vector2>());

    private void Start()
    {
        _input.Player.Use.performed += context => TryPick();
    }

    private void OnEnable()
    {
        _input = new PlayerInput();

        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private bool TryPick()
    {
        if (Physics.Raycast(Ray, out RaycastHit hit, _maxDistance, _searchLayers) == false)
        {
            return false;
        }
        if (hit.collider.TryGetComponent(out DropBase drop) == false)
        {
            return false;
        }

        drop.TryPick(_player);

        return true;
    }
}