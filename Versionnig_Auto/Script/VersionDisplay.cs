using UnityEngine;
using TMPro;


/// <summary>
/// Affiche la version du jeu dans un TextMeshProUGUI.
/// </summary>
public class VersionDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI versionText;

    private void Start()
    {
        TextAsset versionFile = Resources.Load<TextAsset>("version");

        if (versionFile != null && versionText != null)
        {
            versionText.text = "Version : " + versionFile.text;
        }
        else
        {
            Debug.LogWarning("❌ Impossible de charger la version. Vérifie que 'version.txt' existe et que le TextMeshProUGUI est assigné.");
        }
    }
}
