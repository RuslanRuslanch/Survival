using System.Threading.Tasks;

using AppContext = TSI.AppContext;

namespace Item.Weapon.Attack
{
    public abstract class WeaponAttack : IAttacker
    {
        public readonly WeaponAttackParameters Parameters;
        public readonly ITargetFinder TargetFinder;

        public bool CanAttack { get; private set; } = true;

        public PlayerInput Input => AppContext.Instance.PlayerInput;

        protected WeaponAttack(WeaponAttackParameters parameters, ITargetFinder targetFinder)
        {
            Parameters = parameters;
            TargetFinder = targetFinder;
        }

        public abstract bool TryAttack();
        public abstract void Attack();

        public async void WaitDelay()
        {
            CanAttack = false;

            await Task.Delay(Parameters.RateInMiliseconds);

            CanAttack = true;
        }
    }
}