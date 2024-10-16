using System;

namespace TSI.HP
{
    public class Health
    {
        private float _currentHealth;

        public readonly float MaxHealth;

        public float CurrentHealth
        {
            get { return _currentHealth; }
            private set { _currentHealth = Math.Clamp(value, 0, MaxHealth); }
        }

        public bool IsDead => CurrentHealth == 0f;
        public bool IsFull => CurrentHealth == MaxHealth;

        public event Action HealthOver;
        public event Action HealthChanged;

        public Health(float startHealth, float maxHealth)
        {
            MaxHealth = maxHealth;

            Add(startHealth);
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

            if (IsDead)
                HealthOver?.Invoke();
        }

        public bool TryTake(float amount)
        {
            if (amount < 0f)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (IsDead)
                return false;

            Take(amount);

            return true;
        }

        public bool TryAdd(float amount)
        {
            if (amount < 0f)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (IsDead)
                return false;

            Add(amount);

            return true;
        }
    }
}