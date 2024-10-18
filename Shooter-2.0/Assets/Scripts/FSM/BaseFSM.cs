using System;
using System.Linq;
using TSI.FSM.State;

namespace TSI.FSM
{
    public class BaseFSM
    {
        public FSMState CurrentState { get; private set; }

        private readonly FSMState[] _allStates;

        public BaseFSM(FSMState[] allStates)
        {
            _allStates = allStates;

            CurrentState = _allStates[0];
            CurrentState.Start();
        }

        public void SwitchState<T>() where T : FSMState
        {
            var newState = _allStates.FirstOrDefault(state => state is T);

            if (newState == null)
                throw new NullReferenceException(nameof(newState));

            CurrentState?.Stop();
            newState.Start();

            CurrentState = newState;
        }
    }
}