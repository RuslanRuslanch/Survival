using Unity.VisualScripting;
using UnityEngine;

public class TreeView : ResourceView
{
    [Header("Fall settings")]
    [SerializeField, Min(0f)] private float _despawnDelay;
    [SerializeField, Min(1f)] private float _pushForce;

    public override void OnMined()
    {
        var rigidbody = Resource.AddComponent<Rigidbody>();

        var direction = Camera.main.transform.forward;
        var velocity = direction * _pushForce;

        rigidbody.AddForce(velocity, ForceMode.Impulse);

        Destroy(Resource.gameObject, _despawnDelay);
    }
}