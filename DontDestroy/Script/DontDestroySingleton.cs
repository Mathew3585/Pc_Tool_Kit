using UnityEngine;

/// <summary>
/// Emp�che la destruction du GameObject et �vite les doublons.
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
