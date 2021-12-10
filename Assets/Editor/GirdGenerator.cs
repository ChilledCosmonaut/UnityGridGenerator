using System;
using UnityEditor;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace TilePathfinding
{
    [CustomEditor(typeof(Grid))]
    public class GirdGenerator : Editor
    {
        private Grid grid;

        private void OnEnable()
        {
            // Method 1
            grid = (Grid) target;
        }

        public override void OnInspectorGUI()
        {
            // Draw default inspector after button...
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Create Grid"))
            {
                grid.GenerateGrid(new Vector3(30, 30, 7));
                Debug.Log(grid.Tiles.Count);
            }
        }
    }
}

