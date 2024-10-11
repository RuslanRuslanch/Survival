using TSI.Drop;
using UnityEngine;

namespace TSI.Entities.Character.State
{
    public class GroundMoveState : PlayerState
    {
        private readonly DropPicker _dropPicker;
        private readonly IMovementLogic _moveLogic, _cameraLogic;

        public GroundMoveState(IStateSwitcher stateSwitcher, DropPicker picker, IMovementLogic moveLogic, IMovementLogic cameraLogic) : base(stateSwitcher)
        {
            _moveLogic = moveLogic;
            _cameraLogic = cameraLogic;
            _dropPicker = picker;
        }

        public override void Attack()
        {
            Debug.Log("Player attack");
        }

        public override void Build()
        {
            return;
        }

        public override void Move()
        {
            Debug.Log("Player walk");

            _moveLogic.Update();
            _cameraLogic.Update();
        }

        public override void Pick()
        {
            Debug.Log("Player pick");

            _dropPicker.TryPick();
        }

        public override void Start()
        {
            return;
        }

        public override void Stop()
        {
            return;
        }
    }
}