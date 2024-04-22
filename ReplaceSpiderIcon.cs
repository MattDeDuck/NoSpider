using BepInEx.Logging;
using HarmonyLib;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace NoSpider
{
    class ReplaceSpiderIcon
    {
        static ManualLogSource Log => Plugin.Log;

        [HarmonyPostfix, HarmonyPatch(typeof(DailyTidyMenu), "SetupMenuItems")]
        public static void SetupMenuItems_Postfix()
        {
            // Find the Daily Tidy Level
            DailyTidyLevelIcon dailyTidyIcon = Resources.FindObjectsOfTypeAll<DailyTidyLevelIcon>().Where(c => c.name == "Daily Tidy Level Icon").First();
            LevelInterface dailyTidyLevel = dailyTidyIcon.IconLevel;

            // Check to see if it's a SpiderWeb level
            if (dailyTidyLevel.LevelId == "SpiderWeb")
            {
                // Get the icon image
                Image dailyTidyLevelIcon = dailyTidyIcon.GetComponent<DailyTidyLevelIcon>().IconImage;

                // Change the image
                dailyTidyLevelIcon.sprite = Storage.flyWebSprite;
                Log.LogInfo($"{dailyTidyLevel.Level} - Icon changed");
            }
        }
    }
}
