using System;
using UnityEngine;

namespace TSI.Items
{
    [Serializable]
    public class FoodSaturations
    {
        [Header("Saturations")]
        [SerializeField, Range(0, 100)] private int _food;
        [SerializeField, Range(0, 100)] private int _water;
        [SerializeField, Range(0, 100)] private int _stamina;

        public int Food => _food;
        public int Water => _water;
        public int Stamina => _stamina;
    }
}