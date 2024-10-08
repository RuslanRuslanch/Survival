using TMPro;
using UnityEngine;

public class HealthTextView : HealthView
{
    [Header("View")]
    [SerializeField] private TextMeshProUGUI _text;

    protected override void OnChange()
    {
        _text.text = Health.CurrentHealth.ToString();
    }

    protected override void OnOver()
    {
        return;
    }
}