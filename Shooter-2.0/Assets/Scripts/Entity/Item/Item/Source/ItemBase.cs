using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField] private ItemInfo _info;

    public ItemInfo Info => _info;
}
