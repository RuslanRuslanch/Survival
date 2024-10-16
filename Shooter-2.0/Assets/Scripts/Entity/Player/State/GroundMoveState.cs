using TSI.Character.Movement;
using TSI.Drop;
using TSI.Storages;

namespace TSI.Character.State
{
    public class GroundMoveState : PlayerState
    {
        private readonly SlotSwitcher _switcher;
        private readonly PlayerMovement _movement;
        private readonly DropPicker _dropPicker;

        public GroundMoveState(IStateSwitcher stateSwitcher, PlayerMovement movement, SlotSwitcher switcher, DropPicker dropPicker) : base(stateSwitcher)
        {
            _switcher = switcher;
            _dropPicker = dropPicker;
            _movement = movement;
        }

        public override void Translate()
        {
            _movement.Translate();
        }

        public override void Rotate()
        {
            _movement.Rotate();
        }

        public override void SelectItem()
        {
            //_switcher.TrySwitch();
        }

        public override void Start()
        {

        }

        public override void Stop()
        {

        }

        public override void UseItem()
        {
            //if (_switcher.SelectedItem == null)
            //    return;

            //_switcher.SelectedItem.Use();
        }

        public override void PickUp()
        {
            _dropPicker.TryPick();
        }
    }
}