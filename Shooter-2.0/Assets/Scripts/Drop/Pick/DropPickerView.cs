using UnityEngine;

public class DropPickerView : MonoBehaviour
{
    private DropPicker _picker;

    public void Init(DropPicker picker)
    {
        _picker = picker;

        _picker.DropPicked += OnPick;
        _picker.DropSelected += OnSelect;
    }

    ~DropPickerView()
    {
        _picker.DropPicked -= OnPick;
        _picker.DropSelected -= OnSelect;
    }

    private void OnPick()
    {

    }

    private void OnSelect()
    {

    }
}