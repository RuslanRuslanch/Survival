public abstract class MovementLogic<T> : IMovementLogic where T : MovementData
{
    protected readonly T Data;
    protected readonly PlayerInput Input;

    public MovementLogic(T data, PlayerInput input)
    {
        Data = data;
        Input = input;
    }

    public abstract void Update();
}