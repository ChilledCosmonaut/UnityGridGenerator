using System.Collections.Generic;
using UnityEngine;

namespace TilePathfinding
{
    public class Tile : MonoBehaviour
    {
        public Tile[] Neighbours { get; set; }

        public List<Tile> path = new List<Tile>();

        public string identifier;

        public int tileType;

        public GameObject content;

        public void SetUpTile()
        {
            if(tileType != 0) Instantiate(content, transform);
        }
    }
}