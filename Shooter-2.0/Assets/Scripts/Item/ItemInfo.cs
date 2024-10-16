using UnityEngine;

namespace TSI.Item
{
    [CreateAssetMenu]
    public class ItemInfo : ScriptableObject
    {
        [Header("View")]
        [SerializeField] private string _title = "Безымянный";
        [Space]
        [SerializeField] private string[] _description;
        [Space]
        [SerializeField] private Sprite _icon;

        [Header("Stack")]
        [SerializeField, Min(0)] private int _stackSize = 1;

        public string Title => _title;
        public string[] Description => _description;
        public int StackSize => _stackSize;
        public Sprite Icon => _icon;
    }
}