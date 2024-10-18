using System.Runtime.InteropServices;
using TSI.Character.Movement;
using TSI.Drop;
using TSI.Storage;
using UnityEngine;

namespace TSI.FSM.State
{
    public class PlayerDefaultState : FSMState
    {
        private readonly DropPicker _dropPicker;
        private readonly SlotSwitcher _slotSwitcher;
        private readonly PlayerMovement _movement;
        private readonly StorageUser _inventoryUser;

        public PlayerDefaultState(BaseFSM fsm, DropPicker dropPicker, SlotSwitcher slotSwitcher, PlayerMovement movement, StorageUser inventoryUser) : base(fsm)
        {
            _dropPicker = dropPicker;
            _slotSwitcher = slotSwitcher;
            _movement = movement;
            _inventoryUser = inventoryUser;
        }

        public override void Start()
        {
            Logger.Log("[FSM] Player Default State: Start");
        }

        public override void Stop()
        {
            Logger.Log("[FSM] Player Default State: Stop");
        }

        public override void Update()
        {
            _inventoryUser.TryUse();
            _dropPicker.TryPick();
            _slotSwitcher.TrySwitch();

            _movement.TryRotate();
            _movement.TryTranslate();

            _slotSwitcher.SelectedItem?.TryUse();

            Logger.Log("[FSM] Player Default State: Update");
        }
    }
}