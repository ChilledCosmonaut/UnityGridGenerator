using System;
using TilePathfinding;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridPreset))]
public class GridPresetUi : Editor
{
    private GridPreset gridPreset;

    private void OnEnable()
    {
        gridPreset = (GridPreset) target;
        if (gridPreset.tileSets == null)
        {
            gridPreset.tileSets = new();
            var newPreset = new TilePreset
            {
                instantiationBehaviour = CreateInstance<StandardInstantiateBehaviour>()
            };
            gridPreset.tileSets.Add(newPreset);
        }
    }

    public override void OnInspectorGUI()
    {
        try
        {
            foreach (var preset in gridPreset.tileSets)
            {
                EditorGUILayout.LabelField(preset.name);
            
                EditorGUILayout.Space();
            
                preset.name = EditorGUILayout.TextField("Name",preset.name);
                preset.identifier = EditorGUILayout.IntField("Identifier", preset.identifier);
                preset.presetObject = (GameObject) EditorGUILayout.ObjectField("PresetObject", preset.presetObject, typeof(GameObject), false);
                preset.presetPosition = EditorGUILayout.Vector3Field("Position", preset.presetPosition);
                preset.presetRotation = EditorGUILayout.Vector3Field("Rotation", preset.presetRotation);
                preset.presetScale = EditorGUILayout.Vector3Field("Position", preset.presetScale);
                
                preset.instantiationBehaviour = (InstantiationBehaviour) EditorGUILayout.ObjectField("Instantiation Behaviour", preset.instantiationBehaviour, typeof(InstantiationBehaviour), false);
            
                EditorGUILayout.Space();
            
                if (GUILayout.Button("Delete Preset"))
                {
                    try {
                        gridPreset.tileSets.Remove(preset);
                        if (gridPreset.tileSets.Count == 0)
                        {
                            var standardPreset = new TilePreset
                            {
                                instantiationBehaviour = CreateInstance<StandardInstantiateBehaviour>()
                            };
                            gridPreset.tileSets.Add(standardPreset);
                        }
                    }
                    catch (Exception e)
                    {
                        // ignored
                    }
                    OnInspectorGUI();
                }
            
                EditorGUILayout.Space();
            }
        
            if (GUILayout.Button("Add Preset"))
            {
                var newPreset = new TilePreset
                {
                    instantiationBehaviour = CreateInstance<StandardInstantiateBehaviour>()
                };
                gridPreset.tileSets.Add(newPreset);
            }
        }
        catch (Exception e)
        {
            // ignored
        }
    }
}
