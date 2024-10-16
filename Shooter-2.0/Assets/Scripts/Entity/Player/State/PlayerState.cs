public abstract class PlayerState
{
    public readonly IStateSwitcher StateSwitcher;

    protected PlayerState(IStateSwitcher stateSwitcher)
    {
        StateSwitcher = stateSwitcher;
    }

    public abstract void PickUp();
    public abstract void Translate();
    public abstract void Rotate();
    public abstract void UseItem();
    public abstract void SelectItem();

    public abstract void Start();
    public abstract void Stop();
}
