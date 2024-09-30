using UnityEngine;

[CreateAssetMenu]
public class ItemInfo : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [Space]
    [SerializeField] private Item _prefab;
    [SerializeField] private Sprite _icon;
    [Space]
    [SerializeField, Min(0)] private int _maxAmount;

    public string Name => _name;
    public string Description => _description;
    public int MaxAmount => _maxAmount;
    public Sprite Icon => _icon;
    public Item Prefab => _prefab;
}