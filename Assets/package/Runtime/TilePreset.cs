using System;
using UnityEngine;

namespace TilePathfinding
{
    [CreateAssetMenu(fileName = "GridPreset", menuName = "Grid Preset")]
    public class TilePreset : ScriptableObject
    {
        public new string name;
        public int identifier;
        public GameObject presetObject;
        public Vector3 presetPosition;
        public Vector3 presetRotation;
        public Vector3 presetScale = Vector3.one;
    }
}