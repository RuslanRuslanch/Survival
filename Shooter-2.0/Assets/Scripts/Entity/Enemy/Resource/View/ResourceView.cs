using UnityEngine;

namespace TSI.Resource
{
    public abstract class ResourceView : MonoBehaviour
    {
        [SerializeField] private Resource _resource;

        public Resource Resource => _resource;

        private void OnEnable()
        {
            _resource.ResourceMined += OnMine;
        }

        private void OnDisable()
        {
            _resource.ResourceMined -= OnMine;
        }

        public abstract void OnMine();
    }
}