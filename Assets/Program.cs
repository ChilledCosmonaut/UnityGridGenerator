using System;
using System.Collections.Generic;
using UnityEngine;

namespace TilePathfinding
{
    static class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");
            Grid grid = new Grid(new Vector3(300, 300, 7));
            Console.WriteLine(grid.Tiles.Count);
            var test = grid.Tiles[new Vector3(1, 1, 1)];
            Console.WriteLine(test.Neighbours.Length);
            PathFinder.FindPossiblePaths(grid, new Vector3(1,1,0), 50);
            var pathTest = grid.Tiles[new Vector3(100, 100, 1)];
            Console.WriteLine(pathTest.Path.Count);
            foreach (var VARIABLE in pathTest.Path)
            {
                Console.WriteLine(VARIABLE.Identifier);
            }*/
            int[] testArray = new int[4];

            List<int> testList = new List<int>();
            
            testList.AddRange(testArray);
            
            Console.WriteLine(testList.Count);
        }
    }
}