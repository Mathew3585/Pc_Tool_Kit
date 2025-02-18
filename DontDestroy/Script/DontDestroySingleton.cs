using UnityEngine;

/// <summary>
/// Empêche la destruction du GameObject et évite les doublons.
/// </summary>
public class DontDestroySingleton : MonoBehaviour
{
    private static DontDestroySingleton instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
