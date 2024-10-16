using TSI.HP;

public interface IHealthable
{
    public float MaxHealth { get; }
    public float StartHealth { get; }

    public Health Health { get; }
}
