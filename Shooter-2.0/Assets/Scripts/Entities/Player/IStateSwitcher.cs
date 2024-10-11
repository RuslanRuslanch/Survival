using TSI.Entities.Character.State;

namespace TSI.Entities.Character
{
    public interface IStateSwitcher
    {
        public void SwitchState<T>() where T : PlayerState;
    }
}