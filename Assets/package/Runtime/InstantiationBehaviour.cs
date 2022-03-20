using TilePathfinding;
using UnityEngine;

public abstract class InstantiationBehaviour : ScriptableObject
{
    public abstract GameObject Instantiate(Tile tile, TilePreset content);
}
