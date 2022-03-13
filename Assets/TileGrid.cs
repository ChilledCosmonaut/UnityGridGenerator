using System;
using System.Collections.Generic;
using System.Linq;
using TilePathfinding;
using UnityEngine;

[Serializable]
public sealed class TileGrid : MonoBehaviour
{
    [HideInInspector] 
    public TileMap tiles = new();

    [SerializeField] 
    private TextAsset[] gridBlueprint;
    
    [SerializeField]
    private GridPreset content;

    public Dictionary<int, TilePreset> mappedGridPreset;

    public void GenerateGrid()
    {
        DeleteGrid();
        mappedGridPreset = MapGridPreset();
        String[][][] cache = ConvertGridDescriptionToArray();
        GenerateHeight(cache, Vector3.zero);
    }

    public void DeleteGrid()
    {
        foreach (var tilePair in tiles.Where(tilePair => tilePair.Value != null)) 
            DestroyImmediate(tilePair.Value.gameObject);
        
        tiles.Clear();
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
            var currentLayer = new GameObject{
                transform =
                {
                    parent = transform
                },
                name = $"Layer {indexLength + 1}"
            };
            currentLayer.transform.position += identifier.y * Vector3.up;
            GenerateWidth(cache[indexLength], identifier, currentLayer);
        }

        AssertNeighbours();
    }

    private void GenerateWidth(String[][] cache, Vector3 identifier, GameObject layerParent)
    {
        for (int indexHeight = 0; indexHeight < cache.Length; indexHeight++)
        {
            identifier.z = indexHeight;
            GenerateLength(cache[indexHeight], identifier, layerParent);
        }
    }

    private void GenerateLength(String[] cache, Vector3 identifier, GameObject layerParent)
    {
        for (int indexWidth = 0; indexWidth < cache.Length; indexWidth++)
        {
            identifier.x = indexWidth;
            GenerateTile(cache[indexWidth], identifier, layerParent);
        }
    }

    private void GenerateTile(string tileType, Vector3 identifier, GameObject layerParent)
    {
        var tileObject = new GameObject
        {
            transform =
            {
                parent = layerParent.transform
            }
        };
        tileObject.transform.position += identifier;
        var tile = tileObject.AddComponent<Tile>();
        tiles.Add(identifier, tile);
        tile.tileType = Int32.Parse(tileType);
        tile.content = mappedGridPreset[tile.tileType];
        tile.SetUpTile();
    }

    private void AssertNeighbours()
    {
        foreach (var tile in tiles)
        {
            var neighbours = new List<Vector3>();

            Vector3 upperPossibleTiles = tile.Key + Vector3.up;
            if (tiles.ContainsKey(upperPossibleTiles))
            {
                neighbours.Add(upperPossibleTiles);
                neighbours.AddRange(ScanTileSurroundings(upperPossibleTiles));
            }

            neighbours.AddRange(ScanTileSurroundings(tile.Key));

            Vector3 lowerPossibleTiles = tile.Key + Vector3.down;
            if (tiles.ContainsKey(lowerPossibleTiles))
            {
                neighbours.Add(lowerPossibleTiles);
                neighbours.AddRange(ScanTileSurroundings(lowerPossibleTiles));
            }

            tile.Value.Neighbours = neighbours.ToArray();
        }
    }

    private List<Vector3> ScanTileSurroundings(Vector3 tilePosition)
    {
        List<Vector3> list = new List<Vector3>();
        AddTileToList(list, tilePosition + Vector3.forward);
        AddTileToList(list, tilePosition + Vector3.back);
        AddTileToList(list, tilePosition + Vector3.left);
        AddTileToList(list, tilePosition + Vector3.right);
        return list;
    }

    private void AddTileToList(List<Vector3> list, Vector3 tilePosition)
    {
        if (tiles.ContainsKey(tilePosition))
        {
            list.Add(tilePosition);
        }
    }

    private Dictionary<int, TilePreset> MapGridPreset() =>
        content.tileSets.ToDictionary(preset => preset.identifier);
}