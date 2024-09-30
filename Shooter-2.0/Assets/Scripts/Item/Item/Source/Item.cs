using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ItemInfo _info;

    public ItemInfo Info => _info;
}
