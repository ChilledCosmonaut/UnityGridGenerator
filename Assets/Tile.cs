using System.Collections.Generic;
using UnityEngine;

namespace TilePathfinding
{
    public class Tile
    {
        public Tile[] Neighbours { get; set; }

        public List<Tile> Path = new List<Tile>();

        public string Identifier;

        public Tile(string identifier)
        {
            this.Identifier = identifier;
        }
    }
}