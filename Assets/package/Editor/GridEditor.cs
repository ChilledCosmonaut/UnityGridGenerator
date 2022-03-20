using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GridEditor : EditorWindow
{
    [MenuItem("Tools/Grid Editor")]
    public static void ShowGridEditor()
    {
        EditorWindow gridEditor = GetWindow<GridEditor>();
        gridEditor.titleContent = new GUIContent("Grid Editor");
    }

    public void CreateGUI()
    {
        var splitView = new TwoPaneSplitView(0, 150, TwoPaneSplitViewOrientation.Horizontal);

        var leftPane = new VisualElement();
        splitView.Add(leftPane);
        var rightPane = new VisualElement();
        splitView.Add(rightPane);

        Label levelName = new Label("File Name");
        leftPane.Add(levelName);
        
        rootVisualElement.Add(splitView);
    }
}
