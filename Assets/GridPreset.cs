using TilePathfinding;
using UnityEngine;

[CreateAssetMenu(fileName = "GridPreset", menuName = "Grid Preset")]
public class GridPreset : ScriptableObject
{
    public TilePreset
        floor,
        wall,
        innerCorner,
        outerCorner;

}
