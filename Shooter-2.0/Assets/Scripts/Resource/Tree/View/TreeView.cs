using Unity.VisualScripting;
using UnityEngine;

public class TreeView : ResourceView
{
    private Rigidbody _rigidbody;

    [Header("Fall settings")]
    [SerializeField, Min(0f)] private float _despawnDelay;
    [SerializeField, Min(1f)] private float _pushForce;

    public override void OnMined()
    {
        if (_rigidbody != null)
        {
            return;
        }

        _rigidbody = Resource.AddComponent<Rigidbody>();

        var direction = Camera.main.transform.forward;
        var velocity = direction * _pushForce;

        _rigidbody.AddForce(velocity, ForceMode.Impulse);

        Destroy(Resource.gameObject, _despawnDelay);
    }
}