using System;
using System.Collections;
using System.Collections.Generic;
using TilePathfinding;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace TilePathfinding
{
    public class GirdGenerator : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Grid grid = new Grid(new Vector3(300, 300, 7));
            var test = grid.Tiles[new Vector3(1, 1, 1)];
            PathFinder.FindPossiblePaths(grid, new Vector3(1,1,0), 50);
            Debug.Log($"Grid size is:{grid.Tiles.Count}");
        }
    }
}

