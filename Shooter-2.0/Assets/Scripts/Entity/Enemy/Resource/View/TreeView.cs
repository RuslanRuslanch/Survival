using UnityEngine;

namespace TSI.Resource
{
    public class TreeView : ResourceView
    {
        private Rigidbody _rigidbody;

        public override void OnMine()
        {
            _rigidbody ??= Resource.gameObject.AddComponent<Rigidbody>();

            _rigidbody.AddForce(Camera.main.transform.forward, ForceMode.Impulse);
        }
    }
}