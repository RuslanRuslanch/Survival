public interface IAlternativeAttacker : IAttacker
{
    public bool TryAlternativeAttack();
    public void AlternativeAttack();
}