using System.Linq;
using UnityEditor;
using UnityEngine;

namespace TahaCore.ServiceLocator.Editor
{
    [CustomPropertyDrawer(typeof(ObjectRegistrationInfo))]
    public class ObjectRegistrationInfoDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            SerializedProperty instanceProperty = property.FindPropertyRelative("instance");
            SerializedProperty selectedTypeProperty = property.FindPropertyRelative("selectedTypeName");
            string[] typeNames = null;
            int selectedIndex = 0;
            float lineHeight = EditorGUIUtility.singleLineHeight;

            // Draw the object field
            Rect objectFieldRect = new Rect(position.x, position.y, position.width, lineHeight);
            EditorGUI.PropertyField(objectFieldRect, instanceProperty, label);

            Object selectedObject = instanceProperty.objectReferenceValue;
    
            if (selectedObject != null)
            {
                var types = TypeUtility.GetRegistrableTypes(selectedObject).ToArray();
        
                // Create an array of type names
                typeNames = types.Select(t => t.FullName).ToArray();
            }
            else
            {
                selectedTypeProperty.stringValue = null;
            }

            if (typeNames is { Length: > 0 })
            {
                if (string.IsNullOrEmpty(selectedTypeProperty.stringValue))
                {
                    selectedTypeProperty.stringValue = typeNames[0];
                }
                else
                {
                    selectedIndex = typeNames.ToList().IndexOf(selectedTypeProperty.stringValue);
                    selectedIndex = selectedIndex >= 0 ? selectedIndex : 0;
                    selectedTypeProperty.stringValue = typeNames[selectedIndex];
                }
                
                position.y += 5f;
                // Get the selected type field
                selectedIndex = EditorGUI.Popup(
                    new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight
                        , position.width, EditorGUIUtility.singleLineHeight),
                    "Select Type",
                    selectedIndex,
                    typeNames
                );
                
                // Set the selected type
                selectedTypeProperty.stringValue = typeNames[selectedIndex];
            }
            EditorGUI.EndProperty();
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty instanceProperty = property.FindPropertyRelative("instance");
            if (instanceProperty.objectReferenceValue == null)
                return EditorGUIUtility.singleLineHeight;
            else
                return EditorGUIUtility.singleLineHeight * 2 + 5f;
        }
    }
}