using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DragAndDrop))]
public class DragAndDropEditor : Editor
{
    private SerializedProperty s_rt, s_grid, s_gr,s_es;
    public void OnEnable()
    {
        s_rt = serializedObject.FindProperty("rt");
        s_gr = serializedObject.FindProperty("gr");
        s_grid = serializedObject.FindProperty("grid");
    }
    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(s_gr);
        EditorGUILayout.PropertyField(s_rt);
        EditorGUILayout.PropertyField(s_grid);
        serializedObject.ApplyModifiedProperties();
    }
}
