using System;
using UnityEditor;
using UnityEngine;

namespace TilePathfinding
{
    [CustomEditor(typeof(TilePreset))]
    public class TilePresetUi : Editor
    {
        private TilePreset tilePreset;
        private bool customInstantiationBehaviour;

        private void OnEnable()
        {
            tilePreset = (TilePreset) target;
            
            IfEmptyInitialize();
        }

        public override void OnInspectorGUI()
        {
            for (int index = 0; index < tilePreset.presetObject.Count; index++)
            {
                tilePreset.presetObject[index] = (GameObject)EditorGUILayout.ObjectField("PresetObject", tilePreset.presetObject[index], typeof(GameObject), false);
                tilePreset.presetPosition[index] = EditorGUILayout.Vector3Field("Position", tilePreset.presetPosition[index]);
                tilePreset.presetRotation[index] = EditorGUILayout.Vector3Field("Rotation", tilePreset.presetRotation[index]);
                tilePreset.presetScale[index] = EditorGUILayout.Vector3Field("Position", tilePreset.presetScale[index]);
                
                if (GUILayout.Button("Delete Preset"))
                {
                    try
                    {
                        tilePreset.RemoveObjectAt(index);

                        IfEmptyInitialize();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }

                EditorGUILayout.Separator();
            }

            EditorGUILayout.Space();
            
            if (GUILayout.Button("Add Preset"))
            {
                tilePreset.CreateNewObject();
            }
            EditorGUILayout.Space();

            if (tilePreset.presetObject.Count <= 1)
            {
                customInstantiationBehaviour = EditorGUILayout.Toggle("Custom Instantiation", customInstantiationBehaviour);
                
                if (customInstantiationBehaviour)
                    tilePreset.instantiationBehaviour = (InstantiationBehaviour)EditorGUILayout.ObjectField("Behaviour", tilePreset.instantiationBehaviour, typeof(InstantiationBehaviour), false);
                else
                    tilePreset.instantiationBehaviour = CreateInstance<StandardInstantiateBehaviour>();
            }
            else
            {
                tilePreset.instantiationBehaviour = (InstantiationBehaviour) EditorGUILayout.ObjectField("Custom Instantiation Behaviour", tilePreset.instantiationBehaviour, typeof(InstantiationBehaviour), false);
            }
        }

        private void IfEmptyInitialize()
        {
            if (tilePreset.presetObject.Count <= 0)
            {
                tilePreset.CreateNewObject();
            }
        }
    }
}