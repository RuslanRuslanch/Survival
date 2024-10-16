using System.Linq;
using UnityEngine;

namespace TSI.Item
{
    public class ItemCache : MonoBehaviour
    {
        [SerializeField] private BaseItem[] _cache;

        public static ItemCache Instance;

        public void Initialize()
        {
            Instance ??= this;
        }

        public BaseItem Get(ItemInfo info)
        {
            return _cache.FirstOrDefault(item => item.Info == info);
        }
    }
}