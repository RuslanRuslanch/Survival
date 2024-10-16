using System;

namespace TSI.Character.Movement
{
    public class PlayerMovement
    {
        private PlayerMovementLogic _logic;

        public PlayerMovement(PlayerMovementLogic logic)
        {
            SwitchLogic(logic);
        }

        public void Translate()
        {
            _logic.TryTranslate();
        }

        public void Rotate()
        {
            _logic.TryRotate();
        }

        public void SwitchLogic(PlayerMovementLogic logic)
        {
            if (logic == null)
                throw new NullReferenceException(nameof(logic));

            _logic = logic;
        }
    }
}