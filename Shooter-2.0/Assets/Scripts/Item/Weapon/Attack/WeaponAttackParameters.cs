using System;
using UnityEngine;

namespace Item.Weapon.Attack
{
    [Serializable]
    public class WeaponAttackParameters
    {
        [SerializeField, Min(0f)] private float _damage;
        [SerializeField, Min(0.1f)] private float _rate;

        public readonly int RateInMiliseconds;

        public float Rate => _rate;
        public float Damage => _damage;

        public WeaponAttackParameters()
        {
            RateInMiliseconds = (int)(_rate * 1000f);
        }
    }
}