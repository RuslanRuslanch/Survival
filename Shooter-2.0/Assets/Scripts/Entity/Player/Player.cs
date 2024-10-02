using UnityEngine;

public class Player : Animal
{
    [SerializeField] private Inventory _inventory;

    public Inventory Inventory => _inventory;
}