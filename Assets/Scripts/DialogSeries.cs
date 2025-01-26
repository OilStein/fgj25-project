using System;
using UnityEditor;
using UnityEngine;

public class DialogSeries : ScriptableObject
{
    #if UNITY_EDITOR
    [MenuItem("Assets/Create/DialogSeries")]
    public static void Create()
    {
        var asset = CreateInstance<DialogSeries>();

        AssetDatabase.CreateAsset(asset, "Assets/NewDialogSeries.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
    #endif

    [Serializable]
    public struct DialogEntry
    {
        public AudioClip AudioClip;
        public string SubtitleText;
    }

    public DialogEntry[] Entries;
}