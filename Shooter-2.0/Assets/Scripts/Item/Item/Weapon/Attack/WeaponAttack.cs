using System.Threading.Tasks;

public abstract class WeaponAttack
{
    protected bool CanAttack { get; private set; } = true;
    protected PlayerInput Input { get; private set; }

    public readonly float Damage;
    public readonly float Rate;

    public WeaponAttack(float damage, float rate)
    {
        Damage = damage;
        Rate = rate;

        Input = new PlayerInput();
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

        await Task.Delay((int)(Rate * 1000f));

        CanAttack = true;
    }
}
