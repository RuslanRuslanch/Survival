using System;
using UnityEngine;

public class DefaultTree : Resource
{
    public event Action<Vector3> TreeChoped;

    public override void Extract()
    {
        print("Tree take damage =(");

        if (Health.IsOver)
        {
            TreeChoped?.Invoke(Camera.main.transform.forward);
        }
    }
}
