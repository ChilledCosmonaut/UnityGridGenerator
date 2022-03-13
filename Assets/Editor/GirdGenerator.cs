using UnityEditor;
using UnityEngine;

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
                grid.GenerateGrid();
                Debug.Log($"Created {grid.tiles.Count} Objects....");
            }
            
            if (GUILayout.Button("Delete Grid"))
            {
                Debug.Log($"Deleting {grid.tiles.Count} Objects....");
                grid.DeleteGrid();
            }
        }
    }
}

