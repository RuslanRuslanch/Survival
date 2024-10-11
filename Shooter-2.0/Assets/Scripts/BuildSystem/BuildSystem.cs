using TSI.BuildSystem.Buildings;
using TSI.Factory;
using UnityEngine;

public class BuildSystem
{
    public Building Place(Building building, Vector3 position)
    {
        return BuildingFactory.Instance.Spawn(building, position);
    }
}