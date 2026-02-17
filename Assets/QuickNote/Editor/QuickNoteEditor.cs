using System;
using UnityEditor;
using UnityEngine;

namespace QuickNote
{
    [CustomEditor(typeof(QuickNote))]
    public class QuickNoteEditor : Editor
    {
        private QuickNoteConfig config;

        private readonly DateTime dateTimeInstance = DateTime.Now;

        private void OnEnable()
        {
            string[] guids = AssetDatabase.FindAssets("t:QuickNoteConfig");
            if (guids.Length > 0)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[0]);
                config = AssetDatabase.LoadAssetAtPath<QuickNoteConfig>(path);
            }
            else
            {
                Debug.LogError(
                    "Object of type <QuickNoteConfig> is null. " +
                    "Please ensure there is an instance of <QuickNoteConfig> in the 'QuickNote/Assets' directory."
                );
            }
        }

        public override void OnInspectorGUI()
        {
            QuickNote quickNote = (QuickNote)target;

            var fontSize = config.fontSize;
            var fontColor = config.fontColor;
            var headerColor = config.headerColor;

            var headerStyle = new GUIStyle(EditorStyles.boldLabel);
            headerStyle.normal.textColor = headerColor;
            headerStyle.hover.textColor = headerColor;
            headerStyle.active.textColor = headerColor;
            headerStyle.focused.textColor = headerColor;
            headerStyle.fontSize = 16;

            var headerField = quickNote.GetType().GetField
            (
                "noteHeader",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
            );
            var headerValue = (string)headerField.GetValue(quickNote);
            var newHeaderValue = EditorGUILayout.TextField
            (
                string.IsNullOrEmpty(headerValue) ?
                    "Quick Note" :
                    headerValue, headerStyle
            );
            headerField.SetValue(quickNote, newHeaderValue);

            EditorGUILayout.Space();

            var textAreaStyle = new GUIStyle(EditorStyles.textArea);
            textAreaStyle.normal.textColor = fontColor;
            textAreaStyle.hover.textColor = fontColor;
            textAreaStyle.active.textColor = fontColor;
            textAreaStyle.focused.textColor = fontColor;
            textAreaStyle.fontSize = fontSize;

            var noteField = quickNote.GetType().GetField
            (
                "note",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
            );
            var noteValue = (string)noteField.GetValue(quickNote);
            var newNoteValue = EditorGUILayout.TextArea
            (
                noteValue,
                textAreaStyle,
                GUILayout.Height(config.defaultHeight)
            );
            noteField.SetValue(quickNote, newNoteValue);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Date Last Modified:", AssignModifiedOnDate());
            EditorGUILayout.LabelField("Last Modified By:", AssignLastModifiedBy());

            if (GUI.changed)
                EditorUtility.SetDirty(quickNote);
        }

        private string AssignModifiedOnDate() =>
            DateTime.Now.ToString("yyyy-MM-dd");

        private string AssignLastModifiedBy() =>
            System.Environment.UserName;
    }
}