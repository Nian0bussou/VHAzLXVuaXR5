using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridAsset))]
public class GridEditor : Editor
{
    private SerializedProperty gridProperty;
    private int selGridIndex = 0;

    private void OnEnable()
    {
        gridProperty = serializedObject.FindProperty("grid");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GridAsset grid = (GridAsset)target;
        GUILayout.BeginHorizontal();
        GUILayout.Label("Size");
        EditorGUI.BeginChangeCheck();
        int newSize = EditorGUILayout.IntField(grid.Size);
        if (EditorGUI.EndChangeCheck())
        {
            if (newSize > 0)
                grid.Size = newSize;
            grid.ResetGrid(); 
        }
        GUILayout.EndHorizontal();
        
        DrawGrid(grid);

        GUILayout.BeginHorizontal();
        GUILayout.Label("New Value");
        EditorGUI.BeginChangeCheck();
        int i = selGridIndex / grid.Size;
        int j = selGridIndex % grid.Size;
        int newValue = EditorGUILayout.IntField(grid[i,j]);
        if (EditorGUI.EndChangeCheck())
        {
            grid[i,j] = newValue;
        }
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Reset"))
        {
            grid.ResetGrid();
            selGridIndex = 0;
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawGrid(GridAsset grid)
    {
        GUILayout.BeginVertical();
        EditorGUI.BeginChangeCheck();
        selGridIndex = GUILayout.SelectionGrid(selGridIndex, GetGridStrings(grid), grid.Size);
        if (EditorGUI.EndChangeCheck())
            GUI.FocusControl(null);

        GUILayout.EndVertical();
    }

    //Pourrait être optimisé pour ne pas toujours reconstruire tout le tableau
    //de strings...
    private string[] GetGridStrings(GridAsset grid)
    {
        int n = grid.Size;
        var strings = new string[n * n];

        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                strings[i * n + j] = grid[i,j].ToString();
            }
        }

        return strings;
    }
}
