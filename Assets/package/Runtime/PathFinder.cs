using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace TilePathfinding
{
    public static class PathFinder
    {
        public static void FindPossiblePaths(TileGrid tileGrid, Vector3 start, int maxPathLength)
        {
            Tile startTile = tileGrid.tiles[start];
            startTile.path.Add(start);
            var visited = new Dictionary<Vector3, int> {{start, 0}};

            ExploreGrid(tileGrid, visited, start, 1, maxPathLength);
        }

        private static void ExploreGrid(TileGrid tileGrid, IDictionary<Vector3, int> visited, Vector3 prevPosition,int currentPathLength, int maxPathLength)
        {
            var prevTile = tileGrid.tiles[prevPosition];
            foreach (Vector3 neighbour in prevTile.Neighbours)//Index representation
            {
                if (visited.ContainsKey(neighbour) && currentPathLength < visited[neighbour])
                {
                    visited[neighbour] = currentPathLength;
                    tileGrid.tiles[neighbour].path = new List<Vector3>();
                    tileGrid.tiles[neighbour].path.AddRange(prevTile.path);
                    tileGrid.tiles[neighbour].path.Add(neighbour);
                    
                    if (maxPathLength > currentPathLength)
                    {
                        ExploreGrid(tileGrid, visited, neighbour, currentPathLength + 1, maxPathLength);
                    }
                    
                }else if(!visited.ContainsKey(neighbour))
                {
                    visited.Add(neighbour, currentPathLength);
                    tileGrid.tiles[neighbour].path.AddRange(prevTile.path);
                    tileGrid.tiles[neighbour].path.Add(neighbour);
                    
                    if (maxPathLength > currentPathLength)
                    {
                        ExploreGrid(tileGrid, visited, neighbour, currentPathLength + 1, maxPathLength);
                    }
                }
            }
        }
    }
}