using Unity.VisualScripting;
using UnityEngine;

public class TreeView : MonoBehaviour
{
    [SerializeField] private DefaultTree _tree;

    private void OnEnable()
    {
        _tree.TreeChoped += OnChop;
    }

    private void OnDisable()
    {
        _tree.TreeChoped -= OnChop;
    }

    private void OnChop(Vector3 direction)
    {
        var rigidbody = _tree.AddComponent<Rigidbody>();

        rigidbody.AddForce(direction, ForceMode.Impulse);

        Destroy(_tree.gameObject, 3f);
    }
}