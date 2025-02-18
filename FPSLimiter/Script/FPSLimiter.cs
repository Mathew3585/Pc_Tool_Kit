using UnityEngine;

/// <summary>
/// Gère la limitation du nombre d'images par seconde et permet de modifier dynamiquement cette limite.
/// </summary>
public class FPSLimiter : MonoBehaviour
{
    public static FPSLimiter instance;

    [SerializeField] private int targetFPS = 60;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ApplyFPSLimit();
    }

    /// <summary>
    /// Modifie la limite de FPS et l'applique immédiatement.
    /// </summary>
    /// <param name="newLimit">Nouvelle limite de FPS</param>
    public void SetFPSLimit(int newLimit)
    {
        targetFPS = newLimit;
        ApplyFPSLimit();
    }

    /// <summary>
    /// Applique la limite de FPS définie.
    /// </summary>
    private void ApplyFPSLimit()
    {
        Application.targetFrameRate = targetFPS;
    }
}
