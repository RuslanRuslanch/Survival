using UnityEngine;

public class WeaponSpherecastFinder
{
    private readonly Transform _cameraTransform;

    private readonly float _maxDistance;
    private readonly float _sphereRadius;

    private readonly LayerMask _searchLayers;

    public WeaponSpherecastFinder(float maxDistance, float sphereRadius, LayerMask searchLayers)
    {
        _cameraTransform = Camera.main.transform;

        _maxDistance = maxDistance;
        _sphereRadius = sphereRadius;
        _searchLayers = searchLayers;
    }

    public RaycastHit GetHits()
    {
        var origin = _cameraTransform.position;
        var direction = _cameraTransform.forward;

        var ray = new Ray(origin, direction);

        Physics.SphereCast(ray, _sphereRadius, out var hit, _maxDistance, _searchLayers);
        
        return hit;
    }
}