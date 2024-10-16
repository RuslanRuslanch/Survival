using System.Collections.Generic;
using UnityEngine;

namespace TSI.Factory
{
    public abstract class BaseFactory<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static BaseFactory<T> Instance;

        private readonly List<T> _entities = new List<T>();

        public void Initialize()
        {
            Instance ??= this;
        }

        public void Push(T obj)
        {
            _entities.Add(obj);
        }

        public void Pop(T obj)
        {
            _entities.Remove(obj);
        }

        public abstract T[] Spawn(T obj, int count);
        public abstract T Spawn(T obj);
        public abstract void Despawn(T obj);
    }
}