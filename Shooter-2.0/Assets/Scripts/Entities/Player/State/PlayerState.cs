namespace TSI.Entities.Character.State
{
    public abstract class PlayerState : BaseState
    {
        protected readonly IStateSwitcher _stateSwitcher;

        public PlayerState(IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }

        public abstract void Move();
        public abstract void Build();
        public abstract void Attack();
        public abstract void Pick();
    }
}