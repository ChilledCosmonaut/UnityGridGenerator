using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace TilePathfinding
{
    public static class PathFinder
    {
        public static void FindPossiblePaths(Grid grid, Vector3 start, int maxPathLength)
        {
            Tile startTile = grid.Tiles[start];
            startTile.path.Add(startTile);
            var visited = new Dictionary<Tile, int> {{startTile, 0}};

            ExploreGrid(visited, startTile, 1, maxPathLength);
        }

        private static void ExploreGrid(Dictionary<Tile,int> visited, Tile prevTile,int currentPathLength, int maxPathLength)
        {
            foreach (Tile neighbour in prevTile.Neighbours)//Index representation
            {
                if (visited.ContainsKey(neighbour) && currentPathLength < visited[neighbour])
                {
                    visited[neighbour] = currentPathLength;
                    neighbour.path = new List<Tile>();
                    neighbour.path.AddRange(prevTile.path);
                    neighbour.path.Add(neighbour);
                    
                    if (maxPathLength > currentPathLength)
                    {
                        ExploreGrid(visited, neighbour, currentPathLength + 1, maxPathLength);
                    }
                    
                }else if(!visited.ContainsKey(neighbour))
                {
                    visited.Add(neighbour, currentPathLength);
                    neighbour.path.AddRange(prevTile.path);
                    neighbour.path.Add(neighbour);
                    
                    if (maxPathLength > currentPathLength)
                    {
                        ExploreGrid(visited, neighbour, currentPathLength + 1, maxPathLength);
                    }
                }
            }
        }
    }
}