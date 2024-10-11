using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOverlapFinder
{
    private readonly float _radius;
    private readonly Transform _center;

    public WeaponOverlapFinder(float radius, Transform center)
    {
        _radius = radius;
        _center = center;
    }
    public Collider[] GetHits()
    {
        return Physics.OverlapSphere(_center.position, _radius);
    }
}