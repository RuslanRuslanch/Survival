using UnityEngine;

public class DropView : MonoBehaviour
{
    [SerializeField] private Drop _drop;

    private void OnEnable()
    {
        _drop.DropPicked += OnPick;
    }

    private void OnDisable()
    {
        _drop.DropPicked -= OnPick;
    }

    private void OnPick()
    {
        EntityFactory.Instance.Despawn(_drop);
    }
}