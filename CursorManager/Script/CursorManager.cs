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


    public void ShowAndUnlockCursor()
    {
        UnlockCursor();
        ShowCursor();
    }

    public void HideAndLockCursor()
    {
        HideCursor();
        LockCursor();
    }

    /// <summary>
    /// Affiche le curseur.
    /// </summary>
    private void ShowCursor()
    {
        Cursor.visible = true;
    }

    /// <summary>
    /// Cache le curseur.
    /// </summary>
    private void HideCursor()
    {
        Cursor.visible = false;
    }

    /// <summary>
    /// Verrouille le curseur au centre de l'écran.
    /// </summary>
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// Déverrouille le curseur et le rend libre.
    /// </summary>
    private void UnlockCursor()
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
