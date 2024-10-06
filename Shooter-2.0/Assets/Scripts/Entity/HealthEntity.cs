using UnityEngine;

public abstract class HealthEntity : Entity
{
    [Header("Health")]
    [SerializeField, Min(1f)] private float _maxHealth;
    [SerializeField, Min(1f)] private float _startHealth;

    public Health Health { get; private set; }

    protected override void OnSpawn()
    {
        Health = new Health(_maxHealth, _startHealth);
    }
}