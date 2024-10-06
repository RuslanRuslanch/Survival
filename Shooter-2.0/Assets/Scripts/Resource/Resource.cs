using UnityEngine;

public abstract class Resource : HealthEntity, IExtractable
{
    [Header("Resource Amount")]
    [SerializeField, Min(0)] private int _amount;

    public float Amount => _amount;

    public abstract void Extract();
}
