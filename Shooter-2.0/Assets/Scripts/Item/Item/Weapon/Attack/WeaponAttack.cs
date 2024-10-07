using System.Threading.Tasks;

public abstract class WeaponAttack
{
    protected bool CanAttack { get; private set; } = true;

    protected PlayerInput Input { get; private set; }

    public readonly float Damage;
    public readonly float MaxDistance;
    public readonly byte Power;

    private readonly int _rateInMilliseconds;

    public WeaponAttack(float damage, float rate, float maxDistance, byte power)
    {
        Damage = damage;
        MaxDistance = maxDistance;
        Power = power;

        _rateInMilliseconds = (int)(rate * 1000f);

        Input = new PlayerInput();

        Input.Player.Attack.performed += context => TryAttack();

        Input.Enable();
    }

    ~WeaponAttack()
    {
        Input.Disable();
    }

    public abstract bool TryAttack();
    protected abstract void Attack();

    protected async void WaitDelay()
    {
        CanAttack = false;

        await Task.Delay(_rateInMilliseconds);

        CanAttack = true;
    }
}