using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AudioClipButtonAttribute))]
public class AudioClipButtonDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Calculate the position for the property field
        Rect propertyPosition = position;
        propertyPosition.width -= EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

        // Draw the property field
        EditorGUI.PropertyField(propertyPosition, property, label, true);

        // Calculate the position for the button
        Rect buttonPosition = position;
        buttonPosition.x += propertyPosition.width + EditorGUIUtility.standardVerticalSpacing;
        buttonPosition.width = EditorGUIUtility.singleLineHeight;

        // Draw the button
        if (GUI.Button(buttonPosition, "▶"))
        {
            AudioClip audioClip = (AudioClip)property.objectReferenceValue;
            if (audioClip != null)
            {
                AudioSource audioSource = EditorUtility.CreateGameObjectWithHideFlags("PreviewAudioSource", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
                audioSource.clip = audioClip;
                audioSource.volume = ((AudioClipButtonAttribute)attribute).volume;
                audioSource.pitch = ((AudioClipButtonAttribute)attribute).pitch;
                audioSource.Play();
            }
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property);
    }
}