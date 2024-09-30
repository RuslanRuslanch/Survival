using UnityEngine;

public class Animal : Entity
{
    public Health Health { get; private set; }

    [SerializeField, Min(1f)] private float _maxHealth;
    [SerializeField, Min(0f)] private float _startHealth;

    public override void OnSpawn()
    {
        Health = new Health(_maxHealth, _startHealth);
    }
}