using UnityEngine;

/// <summary>
/// Gère l'affichage, le verrouillage et le changement de sprite du curseur.
/// </summary>
public class CursorManager : MonoBehaviour
{
    public static CursorManager instance;
    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Vector2 hotspot = Vector2.zero;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (!defaultCursor)
        {
            SetCursor(defaultCursor);
        }
    }

    /// <summary>
    /// Affiche le curseur.
    /// </summary>
    public void ShowCursor()
    {
        Cursor.visible = true;
    }

    /// <summary>
    /// Cache le curseur.
    /// </summary>
    public void HideCursor()
    {
        Cursor.visible = false;
    }

    /// <summary>
    /// Verrouille le curseur au centre de l'écran.
    /// </summary>
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// Déverrouille le curseur et le rend libre.
    /// </summary>
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// Change le sprite du curseur.
    /// </summary>
    /// <param name="newCursor">Nouveau sprite du curseur</param>
    public void SetCursor(Texture2D newCursor)
    {
        Cursor.SetCursor(newCursor, hotspot, CursorMode.Auto);
    }
}
