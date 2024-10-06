using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    private Health _health;

    protected Health Health => _health;

    public void Init(Health health)
    {
        _health = health;
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnChange;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnChange;
    }

    protected abstract void OnChange();
}