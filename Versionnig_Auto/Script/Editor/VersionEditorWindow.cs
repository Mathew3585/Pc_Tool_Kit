using UnityEditor;
using UnityEngine;

/// <summary>
/// Fenêtre d’édition permettant de modifier la version du jeu.
/// </summary>
public class VersionEditorWindow : EditorWindow
{
    private int major;
    private int minor;
    private int build;

    [MenuItem("Outils/Gestion Version")]
    public static void ShowWindow()
    {
        GetWindow<VersionEditorWindow>("Gestion Version");
    }

    private void OnEnable()
    {
        BuildVersionManager.LoadVersion();
        major = BuildVersionManager.GetMajorVersion();
        minor = BuildVersionManager.GetMinorVersion();
        build = BuildVersionManager.GetBuildVersion();
    }

    private void OnGUI()
    {
        GUILayout.Label("Modifier la version", EditorStyles.boldLabel);

        major = EditorGUILayout.IntField("Version Majeure", major);
        minor = EditorGUILayout.IntField("Version Mineure", minor);
        build = EditorGUILayout.IntField("Version Build", build);

        if (GUILayout.Button("Sauvegarder Version"))
        {
            BuildVersionManager.SetMajorVersion(major);
            BuildVersionManager.SetMinorVersion(minor);
            BuildVersionManager.SetBuildVersion(build);
            BuildVersionManager.SaveVersion();
            Debug.Log("✅ Version mise à jour !");
        }
    }
}
