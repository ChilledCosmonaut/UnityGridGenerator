using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace TilePathfinding
{
    public static class PathFinder
    {
        public static void FindPossiblePaths(Grid grid, Vector3 start, int maxPathLength)
        {
            Tile startTile = grid.tiles[start];
            startTile.path.Add(start);
            var visited = new Dictionary<Vector3, int> {{start, 0}};

            ExploreGrid(grid, visited, start, 1, maxPathLength);
        }

        private static void ExploreGrid(Grid grid, IDictionary<Vector3, int> visited, Vector3 prevPosition,int currentPathLength, int maxPathLength)
        {
            var prevTile = grid.tiles[prevPosition];
            foreach (Vector3 neighbour in prevTile.Neighbours)//Index representation
            {
                if (visited.ContainsKey(neighbour) && currentPathLength < visited[neighbour])
                {
                    visited[neighbour] = currentPathLength;
                    grid.tiles[neighbour].path = new List<Vector3>();
                    grid.tiles[neighbour].path.AddRange(prevTile.path);
                    grid.tiles[neighbour].path.Add(neighbour);
                    
                    if (maxPathLength > currentPathLength)
                    {
                        ExploreGrid(grid, visited, neighbour, currentPathLength + 1, maxPathLength);
                    }
                    
                }else if(!visited.ContainsKey(neighbour))
                {
                    visited.Add(neighbour, currentPathLength);
                    grid.tiles[neighbour].path.AddRange(prevTile.path);
                    grid.tiles[neighbour].path.Add(neighbour);
                    
                    if (maxPathLength > currentPathLength)
                    {
                        ExploreGrid(grid, visited, neighbour, currentPathLength + 1, maxPathLength);
                    }
                }
            }
        }
    }
}