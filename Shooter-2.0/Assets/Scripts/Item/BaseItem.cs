using UnityEngine;

namespace TSI.Item
{
    public abstract class BaseItem : MonoBehaviour, IUsable
    {
        [Header("Info")]
        [SerializeField] private ItemInfo _info;

        public ItemInfo Info => _info;

        public abstract bool TryUse();
        public abstract void Use();
    }
}