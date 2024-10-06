using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    private void OnEnable()
    {
        OnSpawn();
    }

    private void OnDisable()
    {
        OnDespawn();
    }

    protected virtual void OnSpawn() { }
    protected virtual void OnDespawn() { }
}
