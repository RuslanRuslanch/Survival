using Unity.VisualScripting;
using UnityEngine;

public class TreeView : MonoBehaviour
{
    [SerializeField] private DefaultTree _tree;

    private void OnEnable()
    {
        _tree.ResourceMined += OnChop;
    }

    private void OnDisable()
    {
        _tree.ResourceMined -= OnChop;
    }

    private void OnChop()
    {
        var rigidbody = _tree.AddComponent<Rigidbody>();
        var direction = Camera.main.transform.forward;

        rigidbody.AddForce(direction, ForceMode.Impulse);

        Destroy(_tree.gameObject, 3f);
    }
}