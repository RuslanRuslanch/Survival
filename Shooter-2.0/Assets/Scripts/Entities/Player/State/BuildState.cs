using UnityEngine;

namespace TSI.Entities.Character.State
{
    public class BuildState : PlayerState
    {
        private readonly IMovementLogic _moveLogic, _cameraLogic;

        public BuildState(IStateSwitcher stateSwitcher, IMovementLogic moveLogic, IMovementLogic cameraLogic) : base(stateSwitcher)
        {
            _moveLogic = moveLogic;
            _cameraLogic = cameraLogic;
        }

        public override void Attack()
        {
            return;
        }

        public override void Build()
        {
            Debug.Log("Player build");
        }

        public override void Move()
        {
            Debug.Log("Player move");

            _moveLogic.Update();
            _cameraLogic.Update();
        }

        public override void Pick()
        {
            return;
        }

        public override void Start()
        {
            throw new System.NotImplementedException();
        }

        public override void Stop()
        {
            throw new System.NotImplementedException();
        }
    }
}