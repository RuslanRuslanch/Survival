using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : HealthView
{
    [SerializeField] private Slider _bar;
    [SerializeField] private Gradient _gradient;

    protected override void OnChange()
    {
        float normalizedHealth = Health.CurrentHealth / Health.MaxHealth;

        _bar.image.color = _gradient.Evaluate(normalizedHealth);
        _bar.value = normalizedHealth;
    }
}