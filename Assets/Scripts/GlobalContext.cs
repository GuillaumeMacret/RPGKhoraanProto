using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalContext
{
    public static List<string> FightingEntitiesNamesToInstantiate = new List<string>();
    public static string precSceneName;

    public static bool useSavedPosition = false;
    public static Vector3 playerTransformPosition;
}
