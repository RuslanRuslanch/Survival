using TMPro;
using UnityEngine;

public class AmmoTextView : AmmoView
{
    [Header("View")]
    [SerializeField] private TextMeshProUGUI _text;

    protected override void OnChange()
    {
        _text.text = Ammo.MagazineAmmo.ToString();
    }

    protected override void OnOver()
    {
        return; //TODO: Think about the mechanic
    }
}