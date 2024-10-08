using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class ResourceHitBox : HitBox
{
    [Header("Resource")]
    [SerializeField] private Resource _resource;

    public override void Visit(Axe axe, RaycastHit hit)
    {
        if (CanBeMined(axe))
        {
            return;
        }

        base.Visit(axe, hit);

        _resource.Extract();
    }

    private bool CanBeMined(Tool tool)
    {
        return (tool.Power >= _resource.Endurance && tool.Target == _resource.Type) && ((_resource.Type != ResourceType.None) || (tool.Target != ResourceType.None));
    }
}