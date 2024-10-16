using System;
using TSI.Character;
using UnityEngine;

namespace TSI.Drop
{
    public abstract class BaseDrop : MonoBehaviour, IPickable
    {
        public Action DropPickSuccess;
        public Action DropPickFailed;

        public abstract void Pick(Player player);
        public abstract bool TryPick(Player player);
    }
}
