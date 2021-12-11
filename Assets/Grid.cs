using System;
using System.Collections.Generic;
using TilePathfinding;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public readonly Dictionary<Vector3, Tile> Tiles = new Dictionary<Vector3, Tile>();

    [SerializeField] private TextAsset[] gridBlueprint;

    public void GenerateGrid()
    {
        String[][][] cache = ConvertGridDescriptionToArray();
        GenerateHeight(cache, Vector3.zero);
    }

    private String[][][] ConvertGridDescriptionToArray()
    {
        String[][][] tileTypeArray = new string[gridBlueprint.Length][][];

        for (int floor = 0; floor < gridBlueprint.Length; floor++)
        {
            tileTypeArray[floor] = ConvertFloorFile(gridBlueprint[floor]);
        }

        return tileTypeArray;
    }

    private String[][] ConvertFloorFile(TextAsset floorString)
    {
        String[] floorRows = floorString.text.Split(new[] {"\n"}, StringSplitOptions.None);
        String[][] floorDescription = new string[floorRows.Length][];

        for (int i = 0; i < floorRows.Length; i++)
        {
            floorDescription[i] = floorRows[i].Split(';');
        }

        return floorDescription;
    }

    private void GenerateHeight(String[][][] cache, Vector3 dimensions)
    {
        for (int indexLength = 0; indexLength < cache.Length; indexLength++)
        {
            dimensions.z = indexLength;
            GenerateWidth(cache[indexLength], dimensions);
        }

        AssertNeighbours();
    }

    private void GenerateWidth(String[][] cache, Vector3 dimensions)
    {
        for (int indexHeight = 0; indexHeight < cache.Length; indexHeight++)
        {
            dimensions.y = indexHeight;
            GenerateLength(cache[indexHeight], dimensions);
        }
    }

    private void GenerateLength(String[] cache, Vector3 dimensions)
    {
        for (int indexWidth = 0; indexWidth < cache.Length; indexWidth++)
        {
            dimensions.x = indexWidth;
            GenerateTile(cache[indexWidth], dimensions);
        }
    }

    private void GenerateTile(string tileType, Vector3 identifier)
    {
        Tile tile = new Tile(identifier.ToString());
        Tiles.Add(identifier, tile);
    }

    private void AssertNeighbours()
    {
        foreach (var tile in Tiles)
        {
            var neighbours = new List<Tile>();

            Vector3 upperPossibleTiles = tile.Key + Vector3.up;
            if (Tiles.ContainsKey(upperPossibleTiles))
            {
                neighbours.Add(Tiles[upperPossibleTiles]);
                neighbours.AddRange(ScanTileSurroundings(upperPossibleTiles));
            }

            neighbours.AddRange(ScanTileSurroundings(tile.Key));

            Vector3 lowerPossibleTiles = tile.Key + Vector3.down;
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
        AddTileToList(list, tilePosition + Vector3.forward);
        AddTileToList(list, tilePosition + Vector3.back);
        AddTileToList(list, tilePosition + Vector3.left);
        AddTileToList(list, tilePosition + Vector3.right);
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