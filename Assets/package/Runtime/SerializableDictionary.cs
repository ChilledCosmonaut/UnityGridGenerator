using System;
using System.Collections.Generic;
using UnityEngine;

namespace TilePathfinding
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<TKey> keys = new();
        
        [SerializeField]
        private List<TValue> values = new();

        // save he dictionary to lists
        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();
            foreach (var (key, value) in this)
            {
                keys.Add(key);
                values.Add(value);
            }
        }
        
        // load dictionary from lists
        public void OnAfterDeserialize()
        {
            Clear();

            if (keys.Count != values.Count)
                throw new SystemException("Key and value count do not match. Make sure both types are serializable.");

            for (int index = 0; index < keys.Count; index++)
            {
                Add(keys[index], values[index]);
            }
        }
    }
    
    [Serializable]
    public class TileMap : SerializableDictionary<Vector3, Tile> {}
}