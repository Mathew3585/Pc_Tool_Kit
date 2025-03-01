using UnityEngine;

[CreateAssetMenu(fileName = "DiscordSettings", menuName = "Discord/Settings")]
public class DiscordSettings : ScriptableObject
{
    /// <summary>
    /// Identifiant de l'application Discord utilisé pour le Rich Presence.
    /// </summary>
    public long applicationID;
}
