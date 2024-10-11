using System;
using UnityEngine;

namespace TSI.Items
{
    public abstract class Food : ItemBase
    {
        [Header("Effects")]
        [SerializeField] private FoodSaturations _saturations;

        public FoodSaturations Saturations => _saturations;

        public Action FoodEated;

        public abstract bool TryEat();
        protected abstract void Eat();
    }
}