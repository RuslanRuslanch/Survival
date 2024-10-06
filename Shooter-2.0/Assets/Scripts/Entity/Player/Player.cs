using UnityEngine;

public class Player : HealthEntity
{
    [Header("Drop picker view")]
    [SerializeField] private DropPickerView _pickerView;
    [Space]
    [SerializeField] private float _maxDistance;
    [SerializeField] private LayerMask _searchLayers;

    [Header("Inventory")]
    [SerializeField] private Inventory _inventory;

    public Inventory Inventory => _inventory;

    protected override void OnSpawn()
    {
        base.OnSpawn();

        DropPicker picker = new DropPicker(this, _maxDistance, _searchLayers);

        _pickerView.Init(picker);

    }
}