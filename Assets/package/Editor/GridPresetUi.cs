using UnityEditor;

[CustomEditor(typeof(GridPreset))]
public class GridPresetUi : Editor
{
    private GridPreset gridPreset;
    private bool customInstantiationBehaviour = false;

    private void OnEnable()
    {
        gridPreset = (GridPreset) target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        EditorGUILayout.Space();

        if (gridPreset.tileSets.Count <= 1)
        {
            customInstantiationBehaviour = EditorGUILayout.Toggle("Custom Instantiation", customInstantiationBehaviour);
            if (customInstantiationBehaviour)
            {
                gridPreset.instantiationBehaviour = (InstantiationBehaviour) EditorGUILayout.ObjectField("Behaviour", gridPreset.instantiationBehaviour, typeof(InstantiationBehaviour), false);
            }
        }
        else
        {
            gridPreset.instantiationBehaviour = (InstantiationBehaviour) EditorGUILayout.ObjectField("Custom Instantiation Behaviour", gridPreset.instantiationBehaviour, typeof(InstantiationBehaviour), false);
        }
        
        /*try
        {
            for(int index = 0; index < gridPreset.tileSets.Count; index++)
            {
                EditorGUILayout.LabelField(((Object)this).name);
            
                EditorGUILayout.Space();
            
                /*((Object)this).name = EditorGUILayout.TextField("Name",((Object)this).name);
                preset.identifier = EditorGUILayout.IntField("Identifier", preset.identifier);
                preset.presetObject = (GameObject) EditorGUILayout.ObjectField("PresetObject", preset.presetObject, typeof(GameObject), false);
                preset.presetPosition = EditorGUILayout.Vector3Field("Position", preset.presetPosition);
                preset.presetRotation = EditorGUILayout.Vector3Field("Rotation", preset.presetRotation);
                preset.presetScale = EditorGUILayout.Vector3Field("Position", preset.presetScale);#1#
                
                /*preset.instantiationBehaviour = (InstantiationBehaviour) EditorGUILayout.ObjectField("Instantiation Behaviour", preset.instantiationBehaviour, typeof(InstantiationBehaviour), false);#1#

                gridPreset.tileSets[index] = (TilePreset) EditorGUILayout.ObjectField(gridPreset.tileSets[index].name, gridPreset.tileSets[index], typeof(TilePreset), false);
                
                
                
                EditorGUILayout.Space();
            
                if (GUILayout.Button("Delete Preset"))
                {
                    try {
                        gridPreset.tileSets.Remove(gridPreset.tileSets[index]);
                        if (gridPreset.tileSets.Count <= 0)
                        {
                            var standardPreset = CreateInstance<TilePreset>();
                            gridPreset.tileSets.Add(standardPreset);
                        }

                        if (gridPreset.tileSets.Count <= 1)
                        {
                            gridPreset.instantiationBehaviour = CreateInstance<StandardInstantiateBehaviour>();
                        }
                    }
                    catch (Exception e)
                    {
                        // ignored
                    }
                }
            
                EditorGUILayout.Space();
            }
        
            if (GUILayout.Button("Add Preset"))
            {
                var newPreset = CreateInstance<TilePreset>();
                gridPreset.tileSets.Add(newPreset);
            }
        }
        catch (Exception e)
        {
            // ignored
        }*/
    }
}
