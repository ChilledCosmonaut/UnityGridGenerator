using System.Collections.Generic;
using UnityEngine;

namespace TilePathfinding
{
    [CreateAssetMenu(fileName = "TilePreset", menuName = "Tile Preset")]
    public class TilePreset : ScriptableObject
    {
        public int identifier;
        public List<GameObject> presetObject = new ();
        public List<Vector3> presetPosition = new ();
        public List<Vector3> presetRotation = new ();
        public List<Vector3> presetScale = new ();
        public InstantiationBehaviour instantiationBehaviour;

        public void CreateNewObject()
        {
            presetObject.Add(null);
            presetPosition.Add(Vector3.zero);
            presetRotation.Add(Vector3.zero);
            presetScale.Add(Vector3.one);
        }
        
        public void RemoveObjectAt(int index)
        {
            presetObject.RemoveAt(index);
            presetPosition.RemoveAt(index);
            presetRotation.RemoveAt(index);
            presetScale.RemoveAt(index);
        }
    }
}