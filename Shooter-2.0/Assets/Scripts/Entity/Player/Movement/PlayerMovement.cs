using System;

namespace TSI.Character.Movement
{
    public abstract class PlayerMovement
    {
        public readonly PlayerMovementParameters Parameters;

        public PlayerInput Input => AppContext.Instance.PlayerInput;

        protected PlayerMovement(PlayerMovementParameters parameters)
        {
            Parameters = parameters;
        }

        public abstract bool TryTranslate();
        public abstract bool TryRotate();
    }
}