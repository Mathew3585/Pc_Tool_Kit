using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System.IO;

/// <summary>
/// Gère l'incrémentation automatique de la version lors du build.
/// </summary>
public class BuildVersionManager : IPreprocessBuildWithReport
{
    private static readonly string versionFilePath = "Assets/Resources/version.txt";
    private static int majorVersion = 1;
    private static int minorVersion = 0;
    private static int buildVersion = 0;

    public int callbackOrder => 0;

    /// <summary>
    /// S'exécute avant le build pour incrémenter la version.
    /// </summary>
    public void OnPreprocessBuild(BuildReport report)
    {
        LoadVersion();
        buildVersion++;
        SaveVersion();
    }

    /// <summary>
    /// Charge la version depuis le fichier.
    /// </summary>
    public static void LoadVersion()
    {
        if (File.Exists(versionFilePath))
        {
            string[] versionNumbers = File.ReadAllText(versionFilePath).Split('.');
            if (versionNumbers.Length == 3)
            {
                int.TryParse(versionNumbers[0], out majorVersion);
                int.TryParse(versionNumbers[1], out minorVersion);
                int.TryParse(versionNumbers[2], out buildVersion);
            }
        }
    }

    /// <summary>
    /// Sauvegarde la version mise à jour dans le fichier et dans les PlayerSettings.
    /// </summary>
    public static void SaveVersion()
    {
        string versionString = $"{majorVersion}.{minorVersion}.{buildVersion}";
        File.WriteAllText(versionFilePath, versionString);
        PlayerSettings.bundleVersion = versionString;
        Debug.Log($"🔹 Nouvelle version générée : {PlayerSettings.bundleVersion}");
    }

    public static int GetMajorVersion() => majorVersion;
    public static int GetMinorVersion() => minorVersion;
    public static int GetBuildVersion() => buildVersion;

    public static void SetMajorVersion(int value) => majorVersion = value;
    public static void SetMinorVersion(int value) => minorVersion = value;
    public static void SetBuildVersion(int value) => buildVersion = value;
}
