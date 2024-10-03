using System.Threading.Tasks;

public abstract class WeaponAttack
{
    protected bool CanAttack { get; private set; }

    public readonly float Damage;
    public readonly float Rate;

    private int RateInMilliseconds => (int)(Rate * 1000f);

    public WeaponAttack(float damage, float rate)
    {
        Damage = damage;
        Rate = rate;
    }

    public abstract bool TryAttack();
    protected abstract void Attack();

    protected async void WaitDelay()
    {
        CanAttack = false;

        await Task.Delay(RateInMilliseconds);

        CanAttack = true;
    }
}