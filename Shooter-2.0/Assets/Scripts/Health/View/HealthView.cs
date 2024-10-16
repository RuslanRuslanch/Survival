using TSI.HP;
using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    public Health Health { get; private set; }

    public void Init(Health health)
    {
        Health = health;
    }

    public abstract void OnChange();
    public abstract void OnOver();
}