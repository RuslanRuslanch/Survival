using UnityEngine;

namespace TSI.Storage
{
    public class SlotView : MonoBehaviour
    {
        [SerializeField] private Slot _slot;

        private void OnEnable()
        {
            _slot.ValueChanged += OnChange;
            _slot.ValueOver += OnOver;
        }

        private void OnDisable()
        {
            _slot.ValueChanged -= OnChange;
            _slot.ValueOver -= OnOver;
        }

        public void OnChange()
        {
            print($"{_slot.Stack.Item} : {_slot.Stack.Amount}");
        }

        public void OnOver()
        {
            print($"Resource in [{_slot}] slot over");
        }
    }
}