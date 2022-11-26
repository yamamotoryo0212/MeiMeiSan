using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(HogeData))]
public class InspectorEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        using (new EditorGUI.PropertyScope(position, label, property))
        {
            position.height = EditorGUIUtility.singleLineHeight;

            Rect rect = new Rect(position) { y = position.y };

            SerializedProperty typeProperty = property.FindPropertyRelative("Type");
            typeProperty.enumValueIndex = EditorGUI.Popup(rect, "Type", typeProperty.enumValueIndex, Enum.GetNames(typeof(HogeData.TYPE)));

            switch ((HogeData.TYPE)typeProperty.enumValueIndex)
            {
                case HogeData.TYPE.Type001:
                    Rect TextNameRect = new Rect(rect)
                    {
                        y = rect.y + EditorGUIUtility.singleLineHeight + 2f
                    };
                    SerializedProperty talkNameProperty = property.FindPropertyRelative("TextName");
                    talkNameProperty.stringValue = EditorGUI.TextField(TextNameRect, "text", talkNameProperty.stringValue);

                    Rect talkTextLabelRect = new Rect(TextNameRect)
                    {
                        y = TextNameRect.y + EditorGUIUtility.singleLineHeight + 2f
                    };
                    EditorGUI.LabelField(talkTextLabelRect, "text");

                    Rect talkTextRect = new Rect(talkTextLabelRect)
                    {
                        y = talkTextLabelRect.y + EditorGUIUtility.singleLineHeight + 2f,
                        height = (EditorGUIUtility.singleLineHeight)
                    };
                    SerializedProperty talkTextProperty = property.FindPropertyRelative("TextA");
                    talkTextProperty.stringValue = EditorGUI.TextArea(talkTextRect, talkTextProperty.stringValue);

                    break;
                case HogeData.TYPE.Type002:
                    Rect animationNameRect = new Rect(rect)
                    {
                        y = rect.y + EditorGUIUtility.singleLineHeight + 2f
                    };
                    SerializedProperty animationNameProperty = property.FindPropertyRelative("TextName");
                    animationNameProperty.stringValue = EditorGUI.TextField(animationNameRect, "text", animationNameProperty.stringValue);

                    Rect localMovePointRect = new Rect(animationNameRect)
                    {
                        y = animationNameRect.y + EditorGUIUtility.singleLineHeight + 2f
                    };
                    SerializedProperty localMovePointProperty = property.FindPropertyRelative("VectorText");
                    localMovePointProperty.vector3Value = EditorGUI.Vector3Field(localMovePointRect, "text", localMovePointProperty.vector3Value);
                    break;

                case HogeData.TYPE.Type003:
                    Rect intrect = new Rect(rect)
                    {
                        y = rect.y + EditorGUIUtility.singleLineHeight + 2f
                    };
                    SerializedProperty intProperty = property.FindPropertyRelative("IntText");
                   intProperty.intValue = EditorGUI.IntField(intrect, intProperty.intValue);
                    break;
            }
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float height = EditorGUIUtility.singleLineHeight;

        SerializedProperty actionTypeProperty = property.FindPropertyRelative("Type");
        switch ((HogeData.TYPE)actionTypeProperty.enumValueIndex)
        {
            case HogeData.TYPE.Type001:
                height = 130f;
                break;
            case HogeData.TYPE.Type002:
                height = 70f;
                break;
        }

        return height;
    }
}