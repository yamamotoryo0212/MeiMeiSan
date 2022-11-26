using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(SOManager))]
public class InspectorDataEditor : Editor
{
    private ReorderableList reorderableList;
    private SerializedProperty actionDataList;

    private void OnEnable()
    {
        actionDataList = serializedObject.FindProperty("TypeList");

        reorderableList = new ReorderableList(serializedObject, actionDataList);
        reorderableList.drawElementCallback = (rect, index, active, focused) => {
            var actionData = actionDataList.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(rect, actionData);
        };
        reorderableList.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "List");
        reorderableList.elementHeightCallback = index => EditorGUI.GetPropertyHeight(actionDataList.GetArrayElementAtIndex(index));
    }

    public override void OnInspectorGUI()
    {
        var eventId = serializedObject.FindProperty("_hogeInt");
        EditorGUILayout.PropertyField(eventId);

        var hogestr = serializedObject.FindProperty("_hogeStr");
        EditorGUILayout.PropertyField(hogestr);

        serializedObject.Update();
        reorderableList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}