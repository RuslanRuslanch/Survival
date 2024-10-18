namespace Item.Weapon.Attack
{
    public class WeaponRaycastAttack : WeaponAttack
    {
        public WeaponRaycastAttack(WeaponAttackParameters parameters, ITargetFinder targetFinder) : base(parameters, targetFinder)
        {
        }

        public override void Attack()
        {
            WaitDelay();

            var targets = TargetFinder.Find();

            foreach (var target in targets)
                target.TryTakeDamage(Parameters.Damage);
        }

        public override bool TryAttack()
        {
            if (CanAttack == false)
                return false;

            if (Input.Player.Attack.IsPressed() == false)
                return false;

            Attack();

            return true;
        }
    }
}