using UnityEngine;
using System.Collections;
using UnityEditor;

// Creates a custom Label on the inspector for all the scripts named ScriptName
// Make sure you have a ScriptName script in your
// project, else this will not work.
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
//        //SpawnController spawnController = (SpawnController)target;
//        //DrawDefaultInspector();

//        //serializedObject.Update();
//        //EditorGUI.BeginChangeCheck();

//        //EditorGUILayout.PropertyField(serializedProperty);
//        //spawnController.waveCount = EditorGUILayout.IntField("waveCount", serializedProperty.intValue);
//        //serializedObject.ApplyModifiedProperties();

//        //if (EditorGUI.EndChangeCheck())
//        //{
//        //    spawnController.waves = new Assets.Scripts.Wave[spawnController.waveCount];
//        //}
//    }
//}