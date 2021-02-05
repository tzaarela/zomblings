//using UnityEngine;
//using System.Collections;
//using UnityEditor;

//[CustomEditor(typeof(SpawnController))]
//public class SpawnEditor : Editor
//{
//    SerializedProperty serializedProperty;

//    public void OnEnable()
//    {
//        serializedProperty = serializedObject.FindProperty("waveCount");
//    }

//    public override void OnInspectorGUI()
//    {
//        SpawnController spawnController = (SpawnController)target;
//        DrawDefaultInspector();

//        serializedObject.Update();
//        EditorGUI.BeginChangeCheck();
//        spawnController.waveCount = EditorGUILayout.IntField("waveCount", serializedProperty.intValue);
//        serializedObject.ApplyModifiedProperties();

//        if (EditorGUI.EndChangeCheck())
//        {
//            spawnController.waves = new Assets.Scripts.Wave[spawnController.waveCount];
//        }
//    }
//}