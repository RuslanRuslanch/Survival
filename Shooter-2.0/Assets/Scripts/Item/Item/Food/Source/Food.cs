using UnityEngine;

public abstract class Food : ItemBase
{
    [Header("Effects")]
    [SerializeField] private FoodSaturations _saturations;

    public FoodSaturations Saturations => _saturations;

    public abstract bool TryEat();
    protected abstract void Eat();
}
