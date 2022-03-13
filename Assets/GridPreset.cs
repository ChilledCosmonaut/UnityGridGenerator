using System.Collections.Generic;
using TilePathfinding;
using UnityEngine;

[CreateAssetMenu(fileName = "GridPreset", menuName = "Grid Preset")]
public class GridPreset : ScriptableObject
{
    public List<TilePreset> tileSets;
}
