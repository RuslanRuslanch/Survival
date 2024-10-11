using System.Collections.Generic;
using UnityEngine;

namespace TSI.Factory 
{
    public abstract class BaseFactory<Object> : MonoBehaviour where Object : MonoBehaviour
    {
        protected readonly List<Object> Pool = new List<Object>();

        public static BaseFactory<Object> Instance;

        private void OnEnable()
        {
            Instance = this;
        }

        public abstract Object[] Spawn(Object obj, Vector3 position, int count);
        public abstract Object Spawn(Object obj, Vector3 position);
        public abstract void Despawn(Object obj);
    }
}
