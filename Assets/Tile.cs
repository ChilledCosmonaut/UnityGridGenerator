using System;
using System.Collections.Generic;
using UnityEngine;

namespace TilePathfinding
{
    [Serializable]
    public class Tile
    {
        public Vector3[] Neighbours { get; set; }

        public List<Vector3> path = new();

        public string identifier;

        public Tile(string identifier)
        {
            this.identifier = identifier;
        }
    }
}