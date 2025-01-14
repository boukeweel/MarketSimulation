using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Save the previous GUI enabled state
        GUI.enabled = false;

        // Draw the property as disabled
        EditorGUI.PropertyField(position, property, label);

        // Restore the GUI enabled state
        GUI.enabled = true;
    }
}
