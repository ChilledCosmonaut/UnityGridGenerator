using System;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace TilePathfinding
{
    public class Grid
    {
        public readonly Dictionary<Vector3, Tile> Tiles = new Dictionary<Vector3, Tile>();

        public Grid(Vector3 dimensions)
        {
            for (int indexLength = 0; indexLength < Math.Floor(dimensions.Z); indexLength++)
            {
                GenerateWidth(new Vector3(dimensions.X, dimensions.Y, indexLength));
            }
            
            AssertNeighbours();
        }
        
        private void GenerateWidth(Vector3 dimensions)
        {
            for (int indexHeight = 0; indexHeight < Math.Floor(dimensions.Y); indexHeight++)
            {
                GenerateLength(new Vector3(dimensions.X, indexHeight, dimensions.Z));
            }
        }

        private void GenerateLength(Vector3 dimensions)
        {
            for (int indexWidth = 0; indexWidth < Math.Floor(dimensions.X); indexWidth++)
            {
                GenerateHeight(new Vector3(indexWidth, dimensions.Y, dimensions.Z));
            }
        }

        private void GenerateHeight(Vector3 identifier)
        {
            Tile tile = new Tile(identifier.ToString());
            Tiles.Add(identifier, tile);
        }

        private void AssertNeighbours()
        {
            foreach (var tile in Tiles)
            {
                var neighbours = new List<Tile>();
                
                Vector3 upperPossibleTiles = tile.Key + Vector3.UnitX;
                if (Tiles.ContainsKey(upperPossibleTiles))
                {
                    neighbours.Add(Tiles[upperPossibleTiles]);
                    neighbours.AddRange(ScanTileSurroundings(upperPossibleTiles));
                }
                
                neighbours.AddRange(ScanTileSurroundings(tile.Key));
                
                Vector3 lowerPossibleTiles = tile.Key + Vector3.UnitX;
                if (Tiles.ContainsKey(lowerPossibleTiles))
                {
                    neighbours.Add(Tiles[lowerPossibleTiles]);
                    neighbours.AddRange(ScanTileSurroundings(lowerPossibleTiles));
                }

                tile.Value.Neighbours = neighbours.ToArray();
            }
        }

        private List<Tile> ScanTileSurroundings(Vector3 tilePosition)
        {
            List<Tile> list = new List<Tile>();
            AddTileToList(list, tilePosition + Vector3.UnitY);
            AddTileToList(list, tilePosition - Vector3.UnitY);
            AddTileToList(list, tilePosition + Vector3.UnitZ);
            AddTileToList(list, tilePosition - Vector3.UnitZ);
            return list;
        }

        private void AddTileToList(List<Tile> list, Vector3 tilePosition)
        {
            if (Tiles.ContainsKey(tilePosition))
            {
                list.Add(Tiles[tilePosition]);
            }
        }
    }
}