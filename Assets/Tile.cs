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

        private GameObject instantiatedContent;

        public void SetUpTile()
        {
            if (tileType == 0) return;
            instantiatedContent = Instantiate(content.presetObject, transform);
            instantiatedContent.transform.localPosition = content.presetPosition;
            instantiatedContent.transform.Rotate(content.presetRotation);
            instantiatedContent.transform.localScale = content.presetScale;
            instantiatedContent.name = content.name;
        }
    }
}