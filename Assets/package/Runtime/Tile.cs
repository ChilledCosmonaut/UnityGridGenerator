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

        public int tileType;

        public TilePreset content;

        public InstantiationBehaviour instantiationBehaviour;

        private GameObject instantiatedContent;

        public void SetUpTile()
        {
            if (tileType == 0) return;
            instantiationBehaviour.Instantiate(this, content);
        }
    }
}