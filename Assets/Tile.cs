using System;
using System.Collections.Generic;
using UnityEngine;

namespace TilePathfinding
{
    [Serializable]
    public class Tile : MonoBehaviour
    {
        public Vector3[] Neighbours { get; set; }

        public List<Vector3> path = new ();

        public string identifier;

        public int tileType;

        public GameObject content;

        public void SetUpTile()
        {
            if(tileType != 0) Instantiate(content, transform);
        }
    }
}