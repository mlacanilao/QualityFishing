﻿using System;
using System.Linq;
using BepInEx;
using HarmonyLib;

namespace QualityFishing
{
    internal static class ModInfo
    {
        internal const string Guid = "omegaplatinum.elin.qualityfishing";
        internal const string Name = "Quality Fishing";
        internal const string Version = "2.1.0.1";
        internal const string ModOptionsGuid = "evilmask.elinplugins.modoptions";
        internal const string ModOptionsAssemblyName = "ModOptions";
    }

    [BepInPlugin(GUID: ModInfo.Guid, Name: ModInfo.Name, Version: ModInfo.Version)]
    internal class QualityFishing : BaseUnityPlugin
    {
        internal static QualityFishing Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            QualityFishingConfig.LoadConfig(config: Config);
            Harmony.CreateAndPatchAll(type: typeof(Patcher), harmonyInstanceId: ModInfo.Guid);
        }

        private void Start()
        {
            if (IsModOptionsInstalled())
            {
                try
                {
                    UIController.RegisterUI();
                }
                catch (Exception ex)
                {
                    Log(payload: $"An error occurred during UI registration: {ex.Message}");
                }
            }
            else
            {
                Log(payload: "Mod Options is not installed. Skipping UI registration.");
            }
        }
        
        internal static void Log(object payload)
        {
            Instance?.Logger.LogInfo(data: payload);
        }
        
        private bool IsModOptionsInstalled()
        {
            try
            {
                return AppDomain.CurrentDomain
                    .GetAssemblies()
                    .Any(predicate: assembly => assembly.GetName().Name == ModInfo.ModOptionsAssemblyName);
            }
            catch (Exception ex)
            {
                Log(payload: $"Error while checking for Mod Options: {ex.Message}");
                return false;
            }
        }
    }
}