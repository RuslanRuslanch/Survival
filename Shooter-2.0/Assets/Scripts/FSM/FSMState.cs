namespace TSI.FSM.State
{
    public abstract class FSMState
    {
        public readonly BaseFSM FSM;

        protected FSMState(BaseFSM fsm)
        {
            FSM = fsm;
        }

        public abstract void Start();
        public abstract void Stop();
        public abstract void Update();
    }
}