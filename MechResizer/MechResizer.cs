using System;
using System.Reflection;
using Harmony;
using HBS.Util;
//using Newtonsoft.Json;

namespace MechResizer
{
    public class MechResizer
    {
        internal static Settings ModSettings = new Settings();
        internal static string ModDirectory;

        public static void Init(string directory, string settingsJSON)
        {
            var harmony = HarmonyInstance.Create("com.joelmeador.MechResizer");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            ModDirectory = directory;
            try
            {
                JSONSerializationUtility.FromJSON(ModSettings, settingsJSON);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                ModSettings = new Settings();
            }
        }
    }
}