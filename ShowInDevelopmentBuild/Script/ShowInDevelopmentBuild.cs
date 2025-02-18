using UnityEngine;

/// <summary>
/// Affiche le GameObject uniquement si le jeu est en mode Development Build.
/// </summary>
public class ShowInDevelopmentBuild : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(Debug.isDebugBuild);
    }
}
