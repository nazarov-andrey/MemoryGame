using UnityEngine;
using UnityEditor;
using System;
using MemoryGame.Launcher;

namespace MemoryGame {
	[CustomEditor (typeof (LauncherRootInstaller))]
	public class LauncherRootInstallerEditor : Editor
	{
		private bool foldout;
		private SerializedProperty minutesProperty;
		private SerializedProperty secondsProperty;
		private SerializedProperty menuSceneNameProperty;
		private SerializedProperty gameSceneNameProperty;

		private void OnEnable ()
		{
			minutesProperty = serializedObject.FindProperty ("roundDurationMinutes");
			secondsProperty = serializedObject.FindProperty ("roundDurationSeconds");
			menuSceneNameProperty = serializedObject.FindProperty ("menuSceneName");
			gameSceneNameProperty = serializedObject.FindProperty ("gameSceneName");
		}

		public override void OnInspectorGUI ()
		{
			serializedObject.Update ();

			EditorGUILayout.PropertyField (menuSceneNameProperty);
			EditorGUILayout.PropertyField (gameSceneNameProperty);
			foldout = EditorGUILayout.Foldout (foldout, "Round Duration");
			if (foldout) {
				EditorGUI.indentLevel++;
				EditorGUILayout.PropertyField (minutesProperty, new GUIContent ("Minutes"));
				EditorGUILayout.PropertyField (secondsProperty, new GUIContent ("Seconds"));
				EditorGUI.indentLevel--;
			}

			serializedObject.ApplyModifiedProperties ();
		}
	}
}