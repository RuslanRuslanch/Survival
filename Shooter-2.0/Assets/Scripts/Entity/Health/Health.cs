using System;

public class Health
{
    public readonly float MaxHealth;

    private float _currentHealth;

    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        private set
        {
            _currentHealth = Math.Clamp(value, 0f, MaxHealth);
        }
    }

    public bool IsOver => _currentHealth == 0f;
    public bool IsFull => _currentHealth == MaxHealth;

    public event Action HealthChanged;
    public event Action HealthOver;

    public Health(float maxHealth, float startHealth)
    {
        MaxHealth = maxHealth;

        Add(startHealth);
    }

    public bool TryTake(float amount)
    {
        if (amount < 0f)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }
        if (IsOver)
        {
            return false;
        }

        Take(amount);

        return true;
    }

    public bool TryAdd(float amount)
    {
        if (amount < 0f)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }
        if (IsOver)
        {
            return false;
        }

        Add(amount);

        return true;
    }

    private void Add(float amount)
    {
        CurrentHealth += amount;

        HealthChanged?.Invoke();
    }

    private void Take(float amount)
    {
        CurrentHealth -= amount;

        HealthChanged?.Invoke();

        if (IsOver)
        {
            HealthOver?.Invoke();
        }
    }
}