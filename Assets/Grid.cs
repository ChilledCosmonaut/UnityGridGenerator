using System;
using System.Collections.Generic;
using TilePathfinding;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public readonly Dictionary<Vector3, Tile> Tiles = new Dictionary<Vector3, Tile>();

    [SerializeField] private TextAsset[] gridBlueprint;
    
    public GameObject content;

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
        String[] floorColumns = floorString.text.Split(new[] {"\n"}, StringSplitOptions.None);
        String[][] floorDescription = new string[floorColumns.Length][];

        for (int i = 0; i < floorColumns.Length; i++)
        {
            floorDescription[i] = floorColumns[i].Split(';');
        }

        return floorDescription;
    }

    private void GenerateHeight(String[][][] cache, Vector3 identifier)
    {
        for (int indexLength = 0; indexLength < cache.Length; indexLength++)
        {
            identifier.y = indexLength;
            GenerateWidth(cache[indexLength], identifier);
        }

        AssertNeighbours();
    }

    private void GenerateWidth(String[][] cache, Vector3 identifier)
    {
        for (int indexHeight = 0; indexHeight < cache.Length; indexHeight++)
        {
            identifier.z = indexHeight;
            GenerateLength(cache[indexHeight], identifier);
        }
    }

    private void GenerateLength(String[] cache, Vector3 identifier)
    {
        for (int indexWidth = 0; indexWidth < cache.Length; indexWidth++)
        {
            identifier.x = indexWidth;
            GenerateTile(cache[indexWidth], identifier);
        }
    }

    private void GenerateTile(string tileType, Vector3 identifier)
    {
        GameObject tileObject = new GameObject();
        tileObject.transform.parent = transform;
        tileObject.transform.position += identifier;
        Tile tile = tileObject.AddComponent<Tile>();
        Tiles.Add(identifier, tile);
        tile.content = content;
        tile.tileType = Int32.Parse(tileType);
        tile.SetUpTile();
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