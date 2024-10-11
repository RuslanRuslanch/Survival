using UnityEngine;

[CreateAssetMenu]
public class ItemInfo : ScriptableObject
{
    [Header("View")]
    [SerializeField] private string _name;
    [SerializeField] private string[] _description;
    [Space]
    [SerializeField] private Sprite _icon;
    [Space]
    [Header("Stack")]
    [SerializeField, Min(1)] private int _maxAmount;

    public string Name => _name;
    public string[] Description => _description;
    public Sprite Icon => _icon;

    public int MaxAmount => _maxAmount;
}
