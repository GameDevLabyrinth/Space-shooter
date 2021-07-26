﻿using UnityEditor;
using UnityEngine;

namespace GameDevLabirinth
{
    [CustomPropertyDrawer(typeof(AttentionField))]
    public class AttentionFieldDraw : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            AttentionField field = attribute as AttentionField;

            if (property.objectReferenceValue == null)
            {
                var color = GUI.color;
                GUI.color = field.NullFieldColor;
                EditorGUI.PropertyField(position, property, label);
                GUI.color = color;
            }
            else
                EditorGUI.PropertyField(position, property, label);
        }
    }
}