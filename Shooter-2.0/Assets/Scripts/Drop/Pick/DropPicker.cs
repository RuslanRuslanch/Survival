using System;
using UnityEngine;

public class DropPicker
{
    private readonly PlayerInput _input; 
    private readonly Camera _camera;
    private readonly Player _player;

    private readonly float _maxDistance;
    private readonly LayerMask _searchLayers;

    public event Action DropPicked;
    public event Action DropSelected;

    private Ray Ray => _camera.ScreenPointToRay(_input.Mouse.Position.ReadValue<Vector2>());

    public DropPicker(Player player, float maxDistance, LayerMask searchLayers)
    {
        _maxDistance = maxDistance;
        _searchLayers = searchLayers;

        _player = player;
        _camera = Camera.main;
        _input = new PlayerInput();

        _input.Player.Use.performed += context => TryPick();

        _input.Enable();
    }

    ~DropPicker()
    {
        _input.Disable();
    }

    private bool TryPick()
    {
        if (Physics.Raycast(Ray, out var hit, _maxDistance, _searchLayers) == false)
        {
            return false;
        }
        if (hit.collider.TryGetComponent(out DropBase drop) == false)
        {
            return false;
        }

        drop.TryPick(_player);

        DropPicked?.Invoke();

        return true;
    }
}