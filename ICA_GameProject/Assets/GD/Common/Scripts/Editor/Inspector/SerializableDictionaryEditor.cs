using GD;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using static UnityEditor.EditorGUI;

[CustomEditor(typeof(SerializableDictionary))]
public class SerializableDictionaryEditor : UnityEditor.Editor
{
    private ReorderableList list;

    private readonly int labelWidth = 50;
    private readonly int keyPropertyWidth = 200;
    private readonly int valuePropertyWidth = 400;
    private readonly int propertyHorizontalSeparator = 10;

    public void OnEnable()
    {
        list = new ReorderableList(serializedObject, serializedObject.FindProperty("entries"), true, true, true,
            true);
        list.drawElementCallback = delegate (Rect rect, int index, bool isActive, bool isFocused)
        {
            var element = list.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

            LabelField(position: new Rect(x: rect.x, rect.y, labelWidth, EditorGUIUtility.singleLineHeight), "Key");
            PropertyField(
                new Rect(rect.x + labelWidth, rect.y, keyPropertyWidth, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("key"), GUIContent.none);

            LabelField(
                new UnityEngine.Rect(rect.x + labelWidth + keyPropertyWidth + propertyHorizontalSeparator, rect.y, labelWidth,
                    EditorGUIUtility.singleLineHeight), "Value");
            PropertyField(
                new UnityEngine.Rect(rect.x + 2 * labelWidth + keyPropertyWidth + propertyHorizontalSeparator, rect.y,
                    valuePropertyWidth, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("value"),
                GUIContent.none);
        };

        list.onAddCallback = list =>
        {
            int index = list.serializedProperty.arraySize;
            list.serializedProperty.arraySize++;
            list.index = index;

            var element = list.serializedProperty.GetArrayElementAtIndex(index);
            if (element != null)
                element.FindPropertyRelative("key").stringValue =
                    System.Guid.NewGuid()
                        .ToString(); // Create some kind of unique key, like a GUID or adding a number to the last one.
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}