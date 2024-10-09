using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponRaycastFinder
{
    private readonly Transform _cameraTransform;

    private readonly float _maxDistance;
    private readonly bool _useSpread;
    private readonly float _spreadFactor;
    private readonly int _attackCount;


    private readonly LayerMask _searchLayers;

    private Vector3 Spread => _useSpread ? GetSpread() : Vector3.zero;

    public WeaponRaycastFinder(float maxDistance, bool useSpread, float spreadFactor, int attackCount, LayerMask searchLayers)
    {
        _cameraTransform = Camera.main.transform;

        _maxDistance = maxDistance;
        _useSpread = useSpread;
        _spreadFactor = spreadFactor;
        _attackCount = attackCount;
        _searchLayers = searchLayers;
    }

    public RaycastHit[] GetHits()
    {
        var hits = new List<RaycastHit>();

        for (int i = 0; i < _attackCount; i++)
        {
            Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward + Spread);

            Physics.Raycast(ray, out var hit, _maxDistance, _searchLayers);

            if (hit.collider == null)
            {
                continue;
            }

            hits.Add(hit);
        }

        return hits.ToArray();
    }

    private Vector3 GetSpread()
    {
        return new Vector3()
        {
            x = Random.Range(-_spreadFactor, _spreadFactor),
            y = Random.Range(-_spreadFactor, _spreadFactor),
            z = Random.Range(-_spreadFactor, _spreadFactor),
        };
    }
}
