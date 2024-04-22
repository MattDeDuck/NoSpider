using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NoSpider
{
    [HarmonyPatch(typeof(SpiderWebLevel))]
    [HarmonyPatch("OnFlyPlaced")]
    public static class RemoveSpiderAnim
    {
        static ManualLogSource Log => Plugin.Log;

        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            Log.LogInfo("Removing spider...");

            // Find the bool to set the Spider to active
            // Set it to false
            return new CodeMatcher(instructions)
                .MatchForward(false,
                new CodeMatch(OpCodes.Ldc_I4_1),
                new CodeMatch(OpCodes.Callvirt),
                new CodeMatch(OpCodes.Ldarg_0))
                .SetOpcodeAndAdvance(OpCodes.Ldc_I4_0)
                .InstructionEnumeration();
        }
    }
}
