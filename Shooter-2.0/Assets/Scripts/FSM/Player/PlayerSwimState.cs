using TSI.Character.Movement;

namespace TSI.FSM.State
{
    public class PlayerSwimState : FSMState
    {
        private readonly PlayerMovement _movement;

        public PlayerSwimState(BaseFSM fsm, PlayerMovement movement) : base(fsm)
        {
            _movement = movement;
        }
        public PlayerSwimState(BaseFSM fsm) : base(fsm)
        {
        }

        public override void Start()
        {
            Logger.Log("[FSM] Player Swim State: Start");
        }

        public override void Stop()
        {
            Logger.Log("[FSM] Player Swim State: Stop");
        }

        public override void Update()
        {
            _movement.TryRotate();
            _movement.TryTranslate();

            Logger.Log("[FSM] Player Swim State: Update");
        }
    }
}