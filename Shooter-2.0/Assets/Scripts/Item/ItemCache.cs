using System.Linq;
using UnityEngine;

namespace TSI.Item
{
    public class ItemCache : MonoBehaviour
    {
        [Header("Cached items list")]
        [SerializeField] private BaseItem[] _cache;

        public BaseItem Get(ItemInfo info)
        {
            return _cache.FirstOrDefault(item => item.Info == info);
        }
    }
}