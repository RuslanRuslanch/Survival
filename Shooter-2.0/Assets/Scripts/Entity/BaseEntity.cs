using UnityEngine;

namespace TSI.Entity
{
    public class BaseEntity : MonoBehaviour
    {
        public virtual void Initialize() { }
        public virtual void Deinitialize() { }
    }
}