using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public virtual void OnSpawn() { }

    public virtual void OnDespawn() { }
}
