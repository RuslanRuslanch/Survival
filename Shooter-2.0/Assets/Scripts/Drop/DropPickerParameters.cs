using System;
using TSI.Character;
using UnityEngine;

[Serializable]
public class DropPickerParameters
{
    [SerializeField, Range(0.1f, 2f)] private float _checkRadius;
    [SerializeField, Range(1f, 20f)] private float _maxRayDistance;
    [Space]
    [SerializeField] private Player _player;

    public float CheckRadius => _checkRadius;
    public float MaxRayDistance => _maxRayDistance;
    public Player Player => _player;
}