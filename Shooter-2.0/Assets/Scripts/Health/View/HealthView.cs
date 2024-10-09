using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    protected Health Health { get; private set; }

    public void Init(Health health)
    {
        Health = health;
    }

    private void OnEnable()
    {
        Health.HealthChanged += OnChange;
        Health.HealthOver += OnOver;
    }

    private void OnDisable()
    {
        Health.HealthChanged -= OnChange;
        Health.HealthOver -= OnOver;
    }

    protected abstract void OnChange();
    protected abstract void OnOver();
}