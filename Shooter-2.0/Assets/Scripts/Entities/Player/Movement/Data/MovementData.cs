using System;
using UnityEngine;

namespace TSI.Entities
{
    public class MovementData
    {
        [SerializeField] private Transform _transform;

        public Transform Transform => _transform;
    }
}