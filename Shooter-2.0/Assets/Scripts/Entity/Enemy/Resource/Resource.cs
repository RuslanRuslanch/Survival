using System;
using TSI.Entity;
using UnityEngine;

namespace TSI.Resource
{
    public abstract class Resource : HealthEntity, IHealthable, IExtractable, IDamageable
    {
        [SerializeField] private ResourceType _type;

        public ResourceType Type => _type;

        public Action ResourceMined;

        public abstract void Extract();
        public abstract void TakeDamage(float damage);


        public abstract bool TryExtract();
        public abstract bool TryTakeDamage(float damage);
    }

    public enum ResourceType : byte
    {
        None,
        Tree,
        Stone
    }
}