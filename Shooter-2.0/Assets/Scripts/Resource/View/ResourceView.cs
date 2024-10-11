using UnityEngine;

public abstract class ResourceView : MonoBehaviour
{
    [Header("Resource")]
    [SerializeField] private Resource _resource;

    protected Resource Resource => _resource;

    private void OnEnable()
    {
        _resource.ResourceMined += OnMined;
    }

    private void OnDisable()
    {
        _resource.ResourceMined -= OnMined;
    }

    protected abstract void OnMined();
}