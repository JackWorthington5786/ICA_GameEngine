using UnityEditor;
using UnityEngine;
using TMPro;

// Enumeration for axis alignment options
public enum AxisAlignmentType : sbyte
{
    Forward,
    Backward,
    Up,
    Down,
    Right,
    Left
}

/// <summary>
/// Editor window for inserting a TextMeshPro quad based on the transform and appearance of a target 3D game object.
/// </summary>
/// <remarks>
/// This editor window allows the user to set various properties such as text, size, color, alignment, and more,
/// and automatically creates a TextMeshPro quad that matches the specified target 3D game object.
/// </remarks>
public class TextQuadEditorWindow : EditorWindow
{
    public GameObject targetObject; // The 3D game object to match
    public GameObject createdQuad; // Reference to the created quad
    public string textMeshProText = "Hello World!"; // Default text
    public float textMeshProSize = 8; // Default text size
    public Color textMeshProColor = Color.white; // Default text color
    public bool parentToTarget = true; // Boolean to determine if the quad should be parented to the targetObject
    public TextAlignmentOptions textAlignment = TextAlignmentOptions.Center; // Default text alignment
    public AxisAlignmentType axisAlignment = AxisAlignmentType.Forward; // Default axis alignment
    public FontStyles fontStyle = FontStyles.Normal; // Default font style
    public bool autoSizeFont = true; // Default auto size setting
    public string quadName = "Text Quad"; // Default name for the new quad

    [MenuItem("Tools/DkIT/Text/Add Text Quad %#T")] // Shortcut key: Ctrl+Alt+T (Windows) / Command+Option+T (macOS)
    public static void ShowWindow()
    {
        TextQuadEditorWindow window = GetWindow<TextQuadEditorWindow>("Add Text Quad");

        // Automatically set the targetObject if a single game object is selected in the hierarchy
        if (Selection.activeGameObject != null)
        {
            window.targetObject = Selection.activeGameObject;
        }

        // Set size for the window
        window.minSize = new Vector2(400f, 280f);
        window.maxSize = new Vector2(600f, 280f);
    }

    private void OnGUI()
    {
        GUILayout.Label("Text Quad Settings", EditorStyles.boldLabel);

        // Input field for specifying a name for the new quad
        quadName = EditorGUILayout.TextField("Quad Name", quadName);

        targetObject = EditorGUILayout.ObjectField("Target Object", targetObject, typeof(GameObject), true) as GameObject;

        // Add space between fields
        EditorGUILayout.Space();

        // Input field for TextMeshPro text
        textMeshProText = EditorGUILayout.TextField("Text", textMeshProText);

        // Input field for TextMeshPro text size
        textMeshProSize = EditorGUILayout.FloatField("Size", textMeshProSize);

        // Input field for TextMeshPro text color
        textMeshProColor = EditorGUILayout.ColorField("Color", textMeshProColor);

        // Dropdown for selecting font style
        fontStyle = (FontStyles)EditorGUILayout.EnumPopup("Font Style", fontStyle);

        // Add space between fields
        EditorGUILayout.Space();

        // Dropdown for selecting text alignment
        textAlignment = (TextAlignmentOptions)EditorGUILayout.EnumPopup("Text Alignment", textAlignment);

        // Dropdown for selecting axis alignment
        axisAlignment = (AxisAlignmentType)EditorGUILayout.EnumPopup("Axis Alignment", axisAlignment);

        // Add space between fields
        EditorGUILayout.Space();

        // Toggle for parenting the quad to the targetObject
        parentToTarget = EditorGUILayout.Toggle("Parent to Target", parentToTarget);

        // Toggle for enabling auto size on TextMeshPro
        autoSizeFont = EditorGUILayout.Toggle("Auto Size Font", autoSizeFont);

        // Begin horizontal layout group
        GUILayout.BeginHorizontal();

        // Button to add text
        if (GUILayout.Button("Add Quad"))
        {
            if (targetObject == null)
            {
                Debug.LogError("Target object is not set. Please assign a target object.");
                return;
            }

            AddTextToTarget();
        }

        // Button to remove text (only enabled if a quad has been added)
        GUI.enabled = createdQuad != null;
        if (GUILayout.Button("Remove Quad"))
        {
            RemoveText();
        }
        GUI.enabled = true;

        // Button to set quad in focus (only enabled if a quad has been added)
        GUI.enabled = createdQuad != null;
        if (GUILayout.Button("Set Quad in Focus"))
        {
            SetQuadInFocus();
        }
        GUI.enabled = true;

        // End horizontal layout group
        GUILayout.EndHorizontal();
    }

    private void AddTextToTarget()
    {
        // Remove any existing quad
        RemoveText();

        // Create a new quad with the specified name
        createdQuad = new GameObject(quadName);

        // Match rotation based on the selected axis
        switch (axisAlignment)
        {
            case AxisAlignmentType.Forward:
                createdQuad.transform.rotation = Quaternion.LookRotation(-1 * targetObject.transform.forward, targetObject.transform.up);
                break;

            case AxisAlignmentType.Backward:
                createdQuad.transform.rotation = Quaternion.LookRotation(targetObject.transform.forward, targetObject.transform.up);
                break;

            case AxisAlignmentType.Up:
                createdQuad.transform.rotation = Quaternion.LookRotation(-1 * targetObject.transform.up, targetObject.transform.forward);
                break;

            case AxisAlignmentType.Down:
                createdQuad.transform.rotation = Quaternion.LookRotation(targetObject.transform.up, targetObject.transform.forward);
                break;

            case AxisAlignmentType.Right:
                createdQuad.transform.rotation = Quaternion.LookRotation(-1 * targetObject.transform.right, targetObject.transform.up);
                break;

            case AxisAlignmentType.Left:
                createdQuad.transform.rotation = Quaternion.LookRotation(targetObject.transform.right, targetObject.transform.up);
                break;
        }

        // Add TextMeshPro component to the quad
        TextMeshPro textMeshPro = createdQuad.AddComponent<TextMeshPro>();

        // Set the text from the input field
        textMeshPro.text = textMeshProText;

        // Set the text size
        textMeshPro.fontSize = textMeshProSize;

        // Set the text color
        textMeshPro.color = textMeshProColor;

        // Set the text alignment
        textMeshPro.alignment = textAlignment;

        // Set the font style
        textMeshPro.fontStyle = fontStyle;

        // Set auto size
        textMeshPro.autoSizeTextContainer = autoSizeFont;

        // Automatically size the TextMeshPro component based on the content
        textMeshPro.autoSizeTextContainer = autoSizeFont;

        // Set position
        createdQuad.transform.position = targetObject.transform.position;

        // Parent the quad to the targetObject if specified
        if (parentToTarget)
        {
            //  createdQuad.transform.parent = targetObject.transform;
            createdQuad.transform.SetParent(targetObject.transform, true);
        }

        // Set the Scene view camera to focus on the new quad
        SetQuadInFocus();
    }

    private void RemoveText()
    {
        // Destroy the created quad if it exists
        if (createdQuad != null)
        {
            DestroyImmediate(createdQuad);
            createdQuad = null;
        }
    }

    private void SetQuadInFocus()
    {
        if (SceneView.lastActiveSceneView != null)
        {
            SceneView.lastActiveSceneView.LookAt(targetObject.transform.position, SceneView.lastActiveSceneView.rotation, 5f);
            Selection.activeObject = createdQuad;
        }
    }
}