using UnityEngine;

namespace TSI.Items
{
    public abstract class ItemBase : MonoBehaviour
    {
        [Header("Info")]
        [SerializeField] private ItemInfo _info;

        public ItemInfo Info => _info;
    }
}