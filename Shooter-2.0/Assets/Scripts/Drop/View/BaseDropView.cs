using UnityEngine;

namespace TSI.Drop
{
    public abstract class BaseDropView : MonoBehaviour
    {
        [SerializeField] private BaseDrop _drop;

        public BaseDrop Drop => _drop;

        private void OnEnable()
        {
            _drop.DropPickSuccess += OnPick;
        }

        private void OnDisable()
        {
            _drop.DropPickSuccess -= OnPick;
        }

        public abstract void OnPick();
    }
}