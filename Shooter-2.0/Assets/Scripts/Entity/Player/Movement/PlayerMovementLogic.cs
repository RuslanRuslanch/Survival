namespace TSI.Character.Movement
{
    public abstract class PlayerMovementLogic
    {
        public PlayerInput Input => AppContext.Instance.PlayerInput;

        public readonly PlayerMovementParameters Parameters;

        protected PlayerMovementLogic(PlayerMovementParameters parameters)
        {
            Parameters = parameters;
        }

        public abstract bool TryRotate();
        public abstract bool TryTranslate();
    }
}