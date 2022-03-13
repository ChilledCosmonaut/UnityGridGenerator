using UnityEditor;
using UnityEngine;

namespace TilePathfinding
{
    [CustomEditor(typeof(TileGrid))]
    public class GirdGenerator : Editor
    {
        private TileGrid tileGrid;

        private void OnEnable()
        {
            // Method 1
            tileGrid = (TileGrid) target;
        }

        public override void OnInspectorGUI()
        {
            // Draw default inspector after button...
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Create Grid"))
            {
                tileGrid.GenerateGrid();
                Debug.Log($"Created {tileGrid.tiles.Count} Objects....");
            }
            
            if (GUILayout.Button("Delete Grid"))
            {
                Debug.Log($"Deleting {tileGrid.tiles.Count} Objects....");
                tileGrid.DeleteGrid();
            }
        }
    }
}

