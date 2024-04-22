using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace NoSpider
{
    [BepInPlugin("org.bepinex.plugins.NoSpider", "A Little to the Left No Spider", "1.0.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log { get; set; }
        public static string pluginLoc = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private void Awake()
        {
            Log = this.Logger;

            Storage.flyWebTex = Storage.LoadTextureFromFile(pluginLoc + "/flyonweb.png");
            Storage.flyWebSprite = Sprite.Create(Storage.flyWebTex, new Rect(0, 0, Storage.flyWebTex.width, Storage.flyWebTex.height), new Vector2(0.5f, 0.5f));

            Harmony.CreateAndPatchAll(typeof(Plugin));
            Harmony.CreateAndPatchAll(typeof(RemoveSpiderAnim));
            Harmony.CreateAndPatchAll(typeof(ReplaceSpiderIcon));
            Harmony.CreateAndPatchAll(typeof(Storage));
        }
    }
}
