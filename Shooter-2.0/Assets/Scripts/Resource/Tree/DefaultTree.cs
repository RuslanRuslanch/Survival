using System;
using UnityEngine;

public class DefaultTree : Resource
{
    public override void Extract()
    {
        print("Tree take damage");

        if (Health.IsOver)
        {
            ResourceMined?.Invoke();
        }
    }
}

public class BigStone : Resource
{
    public override void Extract()
    {
        throw new NotImplementedException();
    }
}
