//using UnityEngine;
//using System.Collections;
//using UnityEditor;

//// Creates a custom Label on the inspector for all the scripts named ScriptName
//// Make sure you have a ScriptName script in your
//// project, else this will not work.
//[CustomEditor(typeof(TeleporterExit))]
//public class TestOnInspector : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        var transform = Selection.activeTransform;
//        var isPressed = GUILayout.Button("Flip it");

//        if (isPressed)
//            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

//    }
//}