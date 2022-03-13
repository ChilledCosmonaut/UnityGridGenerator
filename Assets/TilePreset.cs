using System;
using UnityEngine;

namespace TilePathfinding
{
    [Serializable]
    public class TilePreset
    {
        public string name;
        public int identifier;
        public GameObject presetObject;
        public Vector3 presetPosition;
        public Vector3 presetRotation;
        public Vector3 presetScale = Vector3.one;
    }
}