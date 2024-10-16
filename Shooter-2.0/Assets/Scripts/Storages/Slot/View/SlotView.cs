using UnityEngine;

namespace TSI.Storages
{
    public class SlotView : MonoBehaviour
    {
        public Slot Slot { get; private set; }

        public void Init(Slot slot)
        {
            Slot = slot;
        }

        private void OnEnable()
        {
            Slot.ValueChanged += OnChange;
            Slot.ValueOver += OnOver;
        }

        private void OnDisable()
        {
            Slot.ValueChanged -= OnChange;
            Slot.ValueOver -= OnOver;
        }

        public void OnChange()
        {

        }

        public void OnOver()
        {

        }
    }
}