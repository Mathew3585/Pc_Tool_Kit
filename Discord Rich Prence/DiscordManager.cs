using UnityEngine;
using Discord;
using System;

public class DiscordManager : MonoBehaviour
{
    /// <summary>
    /// Référence aux paramètres Discord contenant l'Application ID.
    /// </summary>
    [SerializeField] private DiscordSettings discordSettings;

    private Discord.Discord discord;
    private ActivityManager activityManager;
    private long startTime;

    private void Start()
    {
        if (discordSettings == null || discordSettings.applicationID == 0)
        {
            Debug.LogError("DiscordSettings est manquant ou l'Application ID est invalide.");
            return;
        }

        discord = new Discord.Discord(discordSettings.applicationID, (ulong)CreateFlags.Default);
        activityManager = discord.GetActivityManager();

        startTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        UpdateRichPresence();
    }

    private void Update()
    {
        if (discord == null) return;
        discord.RunCallbacks();
    }

    private void UpdateRichPresence()
    {
        var activity = new Activity
        {
            Timestamps =
            {
                Start = startTime
            }
        };

        activityManager.UpdateActivity(activity, result =>
        {
            if (result == Result.Ok)
            {
                Debug.Log("Rich Presence mis à jour avec succès !");
            }
            else
            {
                Debug.LogError("Échec de la mise à jour du Rich Presence.");
            }
        });
    }

    private void OnApplicationQuit()
    {
        discord?.Dispose();
    }
}
